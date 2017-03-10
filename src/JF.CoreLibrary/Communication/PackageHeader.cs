using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JF.Communication
{
	public class PackageHeader
	{
		#region 成员字段

		private string _name;
		private string _value;

		#endregion

		#region 构造方法

		public PackageHeader(string name, string value)
		{
			if(string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("name");
			}

			_name = name.Trim();
			_value = value;
		}

		#endregion

		#region 公共属性

		public string Name
		{
			get
			{
				return _name;
			}
		}

		public virtual string Value
		{
			get
			{
				return _value;
			}
		}

		#endregion
	}
}