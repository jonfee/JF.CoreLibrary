using System;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace JF.Runtime.Serialization
{
	public class SerializationContext : MarshalByRefObject
	{
		#region 成员字段

		private ISerializer _serializer;
		private Stream _serializationStream;
		private object _serializationObject;
		private SerializationSettings _settings;
		private IDictionary<string, object> _properties;

		#endregion

		#region 构造方法

		public SerializationContext(ISerializer serializer, Stream serializationStream, object serializationObject, SerializationSettings settings)
		{
			if(serializer == null)
			{
				throw new ArgumentNullException("serializer");
			}

			if(serializationObject == null)
			{
				throw new ArgumentNullException("serializationObject");
			}

			if(serializationStream == null)
			{
				throw new ArgumentNullException("serializationStream");
			}

			_settings = settings;
			_serializer = serializer;
			_serializationStream = serializationStream;
			_serializationObject = serializationObject;
		}

		#endregion

		#region 公共属性

		public ISerializer Serializer
		{
			get
			{
				return _serializer;
			}
		}

		public Stream SerializationStream
		{
			get
			{
				return _serializationStream;
			}
		}

		public object SerializationObject
		{
			get
			{
				return _serializationObject;
			}
		}

		public SerializationSettings Settings
		{
			get
			{
				return _settings;
			}
		}

		public bool HasProperties
		{
			get
			{
				return _properties != null && _properties.Count > 0;
			}
		}

		public IDictionary<string, object> Properties
		{
			get
			{
				if(_properties == null)
				{
					System.Threading.Interlocked.CompareExchange(ref _properties, new ConcurrentDictionary<string, object>(StringComparer.OrdinalIgnoreCase), null);
				}

				return _properties;
			}
		}

		#endregion
	}
}