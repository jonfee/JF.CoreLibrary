using System;
using System.Collections;
using System.Collections.Generic;
using JF.Collections;

namespace JF.IO
{
	/// <summary>
	/// 表示存储文件的容器信息类。
	/// </summary>
	[Serializable]
	[Obsolete("Please use Aliyun-OSS providr of filesystem.")]
	public class StorageBucketInfo : MarshalByRefObject
	{
		#region 成员字段

		private int _bucketId;
		private string _name;
		private string _path;
		private string _title;
		private DateTime _createdTime;
		private DateTime? _modifiedTime;

		#endregion

		#region 构造方法

		public StorageBucketInfo()
		{
			_createdTime = DateTime.Now;
		}

		public StorageBucketInfo(int bucketId)
		{
			_createdTime = DateTime.Now;
		}

		#endregion

		#region 公共属性

		/// <summary>
		/// 获取或设置文件存储容器的编号。
		/// </summary>
		public int BucketId
		{
			get
			{
				return _bucketId;
			}
			set
			{
				_bucketId = value;
			}
		}

		/// <summary>
		/// 获取或设置文件存储容器的名称。
		/// </summary>
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value == null ? string.Empty : value.Trim();
			}
		}

		/// <summary>
		/// 获取或设置文件容器的存储路径。
		/// </summary>
		public string Path
		{
			get
			{
				return _path;
			}
			set
			{
				_path = value;
			}
		}

		/// <summary>
		/// 获取或设置文件存储容器的标题。
		/// </summary>
		public string Title
		{
			get
			{
				return _title;
			}
			set
			{
				_title = value;
			}
		}

		/// <summary>
		/// 获取或设置文件存储容器的创建时间。
		/// </summary>
		public DateTime CreatedTime
		{
			get
			{
				return _createdTime;
			}
			set
			{
				_createdTime = value;
			}
		}

		/// <summary>
		/// 获取或设置文件存储容器的修改时间。
		/// </summary>
		public DateTime? ModifiedTime
		{
			get
			{
				return _modifiedTime;
			}
			set
			{
				_modifiedTime = value;
			}
		}

		#endregion

		#region 公共方法

		public IDictionary<string, object> ToDictionary()
		{
			return new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
			{
				{
					"BucketId", _bucketId
				},
				{
					"Name", _name
				},
				{
					"Path", _path
				},
				{
					"Title", _title
				},
				{
					"CreatedTime", _createdTime
				},
				{
					"ModifiedTime", _modifiedTime
				},
			};
		}

		public static StorageBucketInfo FromDictionary(IDictionary dictionary)
		{
			if(dictionary == null || dictionary.Count < 1)
			{
				return null;
			}

			object bucketId, name, title, path, createdTime, modifiedTime;

			if(!dictionary.TryGetValue("BucketId", out bucketId))
			{
				return null;
			}

			if(!dictionary.TryGetValue("Name", out name))
			{
				return null;
			}

			dictionary.TryGetValue("Path", out path);
			dictionary.TryGetValue("Title", out title);
			dictionary.TryGetValue("CreatedTime", out createdTime);
			dictionary.TryGetValue("ModifiedTime", out modifiedTime);

			return new StorageBucketInfo(JF.Common.Convert.ConvertValue<int>(bucketId))
			{
				Name = JF.Common.Convert.ConvertValue<string>(name), Path = JF.Common.Convert.ConvertValue<string>(path), Title = JF.Common.Convert.ConvertValue<string>(title), CreatedTime = JF.Common.Convert.ConvertValue<DateTime>(createdTime), ModifiedTime = JF.Common.Convert.ConvertValue<DateTime?>(modifiedTime),
			};
		}

		#endregion

		#region 重写方法

		public override int GetHashCode()
		{
			return _bucketId;
		}

		public override bool Equals(object obj)
		{
			if(obj == null || obj.GetType() != this.GetType())
			{
				return false;
			}

			return ((StorageBucketInfo)obj).BucketId == this.BucketId;
		}

		public override string ToString()
		{
			if(string.IsNullOrWhiteSpace(_path))
			{
				return string.Format("#{0} {1}", _bucketId.ToString(), _name);
			}
			else
			{
				return string.Format("#{0} {1} ({2})", _bucketId.ToString(), _name, _path);
			}
		}

		#endregion
	}
}