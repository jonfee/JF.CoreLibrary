using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace JF.Communication
{
	public class PackageContent
	{
		#region 私有变量

		private readonly object _syncRoot;

		#endregion

		#region 成员字段

		private PackageHeaderCollection<PackageContent> _headers;
		private byte[] _contentBuffer;
		private Stream _contentStream;
		private int _contentLength;

		#endregion

		#region 构造方法

		public PackageContent()
		{
			_syncRoot = new object();
		}

		#endregion

		#region 公共属性

		public PackageHeaderCollection<PackageContent> Headers
		{
			get
			{
				if(_headers == null)
				{
					System.Threading.Interlocked.CompareExchange(ref _headers, new PackageHeaderCollection<PackageContent>(this), null);
				}

				return _headers;
			}
		}

		public int ContentLength
		{
			get
			{
				if(_contentLength <= 0)
				{
					if(_contentBuffer != null)
					{
						return _contentBuffer.Length;
					}
					if(_contentStream != null && _contentStream.CanSeek)
					{
						return (int)_contentStream.Length;
					}
				}

				return _contentLength;
			}
			set
			{
				_contentLength = value;
			}
		}

		public byte[] ContentBuffer
		{
			get
			{
				return _contentBuffer;
			}
			set
			{
				_contentBuffer = value;
			}
		}

		public Stream ContentStream
		{
			get
			{
				return _contentStream;
			}
			set
			{
				_contentStream = value;
			}
		}

		#endregion
	}
}