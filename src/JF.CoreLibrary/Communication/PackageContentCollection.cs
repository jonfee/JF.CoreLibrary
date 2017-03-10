using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JF.Communication
{
	public class PackageContentCollection : List<PackageContent>
	{
		#region 成员字段

		private Package _package;

		#endregion

		#region 构造方法

		public PackageContentCollection(Package package)
		{
			if(package == null)
			{
				throw new ArgumentNullException("package");
			}

			_package = package;
		}

		#endregion

		#region 公共属性

		public Package Package
		{
			get
			{
				return _package;
			}
		}

		#endregion
	}
}