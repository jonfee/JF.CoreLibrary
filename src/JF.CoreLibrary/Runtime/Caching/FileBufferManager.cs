using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Collections;
using System.Collections.Generic;

namespace JF.Runtime.Caching
{
	public class FileBufferManager : BufferManagerBase
	{
		#region 成员字段

		private int _id;
		private string _cachingDirectory;
		private Dictionary<int, Stream> _mapping;

		#endregion

		#region 构造方法

		public FileBufferManager(string cachingDirectory) : this(cachingDirectory, 1024 * 4)
		{
		}

		public FileBufferManager(string cachingDirectory, int blockSize) : base(blockSize)
		{
			if(string.IsNullOrWhiteSpace(cachingDirectory))
			{
				throw new ArgumentNullException("cachingDirectory");
			}

			this.CachingDirectory = cachingDirectory.Trim();
			_mapping = new Dictionary<int, Stream>();
		}

		#endregion

		#region 公共属性

		public string CachingDirectory
		{
			get
			{
				return _cachingDirectory;
			}
			set
			{
				if(string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException();
				}

				if(!Directory.Exists(value))
				{
					throw new ArgumentException("This '{0}' directory is not existed.", value);
				}

				_cachingDirectory = value;
			}
		}

		#endregion

		#region 重写方法

		public override int Allocate(long size)
		{
			var id = System.Threading.Interlocked.Increment(ref _id);
			var mappedFile = MemoryMappedFile.CreateFromFile(GetBufferFilePath(id), FileMode.Create, GetMappedName(id), size, MemoryMappedFileAccess.ReadWrite);

			lock(((ICollection)_mapping).SyncRoot)
			{
				_mapping[id] = mappedFile.CreateViewStream();
			}

			return id;
		}

		public override void Release(int id)
		{
			Stream stream;

			if(_mapping.TryGetValue(id, out stream))
			{
				if(stream != null)
				{
					stream.Dispose();
				}

				try
				{
					var mappedFile = MemoryMappedFile.OpenExisting(GetMappedName(id));

					if(mappedFile != null)
					{
						mappedFile.Dispose();
					}
				}
				catch
				{
				}
			}
		}

		public override Stream GetStream(int id)
		{
			Stream stream;

			if(_mapping.TryGetValue(id, out stream))
			{
				return stream;
			}

			return null;
		}

		#endregion

		#region 私有方法

		private string GetMappedName(int id)
		{
			return string.Format("{1}#{0}", id, this.GetType().FullName);
		}

		private string GetBufferFilePath(int id)
		{
			return Path.Combine(_cachingDirectory, string.Format("#{0}.buffer", id));
		}

		#endregion
	}
}