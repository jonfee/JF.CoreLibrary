﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using JF.Runtime.Caching;
using JF.Runtime.Serialization;

namespace JF.Communication
{
	public class PackageSerializer : JF.Runtime.Serialization.ISerializer
	{
		#region 单例模式

		public static readonly PackageSerializer Default = new PackageSerializer();

		#endregion

		#region 成员字段

		private IBufferManager _bufferManager;

		#endregion

		#region 构造方法

		public PackageSerializer()
		{
		}

		public PackageSerializer(IBufferManager bufferManager)
		{
			if(bufferManager == null)
			{
				throw new ArgumentNullException("bufferManager");
			}

			_bufferManager = bufferManager;
		}

		#endregion

		#region 公共属性

		public IBufferManager BufferManager
		{
			get
			{
				if(_bufferManager == null)
				{
					System.Threading.Interlocked.CompareExchange(ref _bufferManager, JF.Runtime.Caching.BufferManager.GetBufferManager(this.GetType().FullName + ".cache"), null);
				}

				return _bufferManager;
			}
			set
			{
				if(value == null)
				{
					throw new ArgumentNullException();
				}

				_bufferManager = value;
			}
		}

		#endregion

		#region 反序列化

		T JF.Runtime.Serialization.ISerializer.Deserialize<T>(Stream serializationStream)
		{
			if(typeof(T) == typeof(Package))
			{
				return (T)(object)this.Deserialize(serializationStream);
			}

			throw new NotSupportedException();
		}

		object JF.Runtime.Serialization.ISerializer.Deserialize(Stream serializationStream, Type type)
		{
			if(type == null || type == typeof(Package))
			{
				return this.Deserialize(serializationStream);
			}

			throw new NotSupportedException();
		}

		object JF.Runtime.Serialization.ISerializer.Deserialize(Stream serializationStream)
		{
			return this.Deserialize(serializationStream);
		}

		public Package Deserialize(byte[] serializationBuffer, int index = 0, int count = 0)
		{
			if(serializationBuffer == null || serializationBuffer.Length == 0)
			{
				return null;
			}

			using(var stream = new MemoryStream(serializationBuffer, index, (count > 0 ? count : serializationBuffer.Length - index)))
			{
				return this.Deserialize(stream);
			}
		}

		public Package Deserialize(Stream serializationStream)
		{
			if(serializationStream == null)
			{
				throw new ArgumentNullException("serializationStream");
			}

			if(this.BufferManager == null)
			{
				throw new InvalidOperationException("The value of 'BufferManager' property is null.");
			}

			int lower = serializationStream.ReadByte();
			int upper = serializationStream.ReadByte();

			if(lower < 0 || upper < 0)
			{
				return null;
			}

			var temp = new byte[lower + (upper << 8)];
			if(serializationStream.Read(temp, 0, temp.Length) != temp.Length)
			{
				return null;
			}

			var package = new Package(Uri.UnescapeDataString(Encoding.ASCII.GetString(temp)));

			int headerCount = serializationStream.ReadByte();
			int contentCount = serializationStream.ReadByte();

			if(headerCount > 0)
			{
				this.DeserializeHeaders(serializationStream, package.Headers, headerCount);
			}
			if(contentCount > 0)
			{
				this.DeserializeContents(serializationStream, package, contentCount);
			}

			return package;
		}

		private void DeserializeHeaders(Stream serializationStream, ICollection<PackageHeader> headers, int count)
		{
			int nameLength, valueLength;
			string name = string.Empty;
			string value = null;
			byte[] temp = new byte[0xFF];

			for(int i = 0; i < count; i++)
			{
				nameLength = serializationStream.ReadByte();
				valueLength = serializationStream.ReadByte();

				if(nameLength > 0 && serializationStream.Read(temp, 0, nameLength) == nameLength)
				{
					name = Encoding.UTF8.GetString(temp, 0, nameLength);
				}

				if(valueLength > 0 && serializationStream.Read(temp, 0, valueLength) == valueLength)
				{
					value = Encoding.UTF8.GetString(temp, 0, valueLength);
				}

				if(!string.IsNullOrEmpty(name))
				{
					headers.Add(new PackageHeader(name, value));
				}
			}
		}

		private void DeserializeContents(Stream serializationStream, Package package, int count)
		{
			var bufferManager = this.BufferManager;

			if(bufferManager == null)
			{
				throw new InvalidOperationException("The value of BufferManager property is null.");
			}

			int headerCount;
			byte[] temp = new byte[4];

			for(int i = 0; i < count; i++)
			{
				PackageContent content = new PackageContent();
				headerCount = serializationStream.ReadByte();
				this.DeserializeHeaders(serializationStream, content.Headers, headerCount);

				if(serializationStream.Read(temp, 0, 4) == 4)
				{
					int contentLength = BitConverter.ToInt32(temp, 0);
					int id = bufferManager.Allocate(contentLength);
					bufferManager.Write(id, serializationStream, contentLength);
					content.ContentStream = bufferManager.GetStream(id);
				}

				package.Contents.Add(content);
			}
		}

		#endregion

		#region 序列方法

		void JF.Runtime.Serialization.ISerializer.Serialize(Stream serializationStream, object graph, SerializationSettings settings)
		{
			if(graph == null)
			{
				return;
			}

			if(!(graph is Package))
			{
				throw new ArgumentException("Not supports serialize the graph.");
			}

			this.Serialize(serializationStream, (Package)graph);
		}

		public void Serialize(Stream serializationStream, Package package)
		{
			if(package == null)
			{
				return;
			}

			if(serializationStream == null)
			{
				throw new ArgumentNullException("serializationStream");
			}

			byte[] value = Encoding.ASCII.GetBytes(Uri.EscapeUriString(package.Url));

			if(value.Length > ushort.MaxValue)
			{
				throw new InvalidOperationException("The url length of the Package too large.");
			}

			serializationStream.Write(BitConverter.GetBytes((ushort)value.Length), 0, 2);
			serializationStream.Write(value, 0, value.Length);

			serializationStream.WriteByte((byte)package.Headers.Count);
			serializationStream.WriteByte((byte)package.Contents.Count);

			//序列化包头
			this.SerializeHeaders(serializationStream, package.Headers);
			//序列化包体
			this.SerializeContents(serializationStream, package.Contents);
		}

		private void SerializeHeaders(Stream serializationStream, ICollection<PackageHeader> headers)
		{
			if(headers == null || headers.Count < 1)
			{
				return;
			}

			foreach(var header in headers)
			{
				var bufferName = Encoding.UTF8.GetBytes(header.Name);
				var bufferValue = Encoding.UTF8.GetBytes(header.Value);

				serializationStream.WriteByte((byte)bufferName.Length);
				serializationStream.WriteByte((byte)bufferValue.Length);

				serializationStream.Write(bufferName, 0, (byte)bufferName.Length);
				serializationStream.Write(bufferValue, 0, (byte)bufferValue.Length);
			}
		}

		private void SerializeContents(Stream serializationStream, ICollection<PackageContent> contents)
		{
			if(contents == null || contents.Count < 1)
			{
				return;
			}

			foreach(var content in contents)
			{
				this.SerializeContent(serializationStream, content);
			}
		}

		private void SerializeContent(Stream serializationStream, PackageContent content)
		{
			var headers = content.Headers;

			if(headers == null || headers.Count == 0)
			{
				serializationStream.WriteByte(0);
			}
			else
			{
				serializationStream.WriteByte((byte)headers.Count);
				this.SerializeHeaders(serializationStream, headers);
			}

			if(content.ContentBuffer != null)
			{
				//写入内容数组的实际长度
				serializationStream.Write(BitConverter.GetBytes(content.ContentLength), 0, 4);
				//将内容数组全部写入序列化流
				serializationStream.Write(content.ContentBuffer, 0, content.ContentLength);
			}
			else if(content.ContentStream != null)
			{
				var contentStream = content.ContentStream;

				//写入内容流的实际长度
				serializationStream.Write(BitConverter.GetBytes(content.ContentLength), 0, 4);

				byte[] buffer = new byte[1024];
				int bytesRead = 0;
				int availableLength = content.ContentLength;

				while(availableLength > 0 && (bytesRead = contentStream.Read(buffer, 0, Math.Min(buffer.Length, availableLength))) > 0)
				{
					serializationStream.Write(buffer, 0, bytesRead);
					availableLength -= bytesRead;
				}
			}
		}

		#endregion

		#region 显式实现

		SerializationSettings JF.Runtime.Serialization.ISerializer.Settings
		{
			get
			{
				return null;
			}
		}

		#endregion
	}
}