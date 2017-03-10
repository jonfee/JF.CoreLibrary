using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace JF.Communication
{
	public class PackageHeaderCollection<TOwner> : KeyedCollection<string, PackageHeader>
	{
		#region 成员字段

		private TOwner _owner;

		#endregion

		#region 构造方法

		public PackageHeaderCollection(TOwner owner) : base(StringComparer.OrdinalIgnoreCase)
		{
			if(owner == null)
			{
				throw new ArgumentNullException("owner");
			}

			_owner = owner;
		}

		#endregion

		#region 公共属性

		public TOwner Owner
		{
			get
			{
				return _owner;
			}
		}

		#endregion

		#region 重写方法

		protected override string GetKeyForItem(PackageHeader item)
		{
			return item.Name;
		}

		#endregion

		#region 公共方法

		public PackageHeader Add(string name, string value)
		{
			var header = new PackageHeader(name, value);
			this.Add(header);
			return header;
		}

		#endregion
	}
}