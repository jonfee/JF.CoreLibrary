using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JF.Communication
{
	public class Package : JF.Runtime.Serialization.ISerializable, IDisposable
	{
		#region 成员字段

		private string _url;
		private PackageHeaderCollection<Package> _headers;
		private PackageContentCollection _contents;

		#endregion

		#region 构造方法

		public Package(string url)
		{
			if(string.IsNullOrWhiteSpace(url))
			{
				throw new ArgumentNullException("url");
			}

			_url = url.Trim();
			_headers = new PackageHeaderCollection<Package>(this);
			_contents = new PackageContentCollection(this);
		}

		#endregion

		#region 公共属性

		public string Url
		{
			get
			{
				return _url;
			}
			set
			{
				if(string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException();
				}

				_url = value.Trim();
			}
		}

		public PackageHeaderCollection<Package> Headers
		{
			get
			{
				return _headers;
			}
		}

		public PackageContentCollection Contents
		{
			get
			{
				return _contents;
			}
		}

		#endregion

		#region 序列方法

		public void Serialize(Stream serializationStream)
		{
			PackageSerializer.Default.Serialize(serializationStream, this);
		}

		public byte[] ToArray()
		{
			using(var ms = new MemoryStream())
			{
				this.Serialize(ms);
				return ms.ToArray();
			}
		}

		#endregion

		#region 处置方法

		public void Dispose()
		{
			if(_contents == null)
			{
				return;
			}

			foreach(var content in _contents)
			{
				if(content != null)
				{
					if(content.ContentStream != null)
					{
						content.ContentStream.Dispose();
					}

					content.ContentBuffer = null;
					content.ContentStream = null;
				}
			}
		}

		#endregion
	}
}