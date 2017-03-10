using System;
using System.Collections.Generic;
using System.Text;

namespace JF.ComponentModel
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	public class AliasAttribute : Attribute
	{
		#region 成员字段

		private string _alias;

		#endregion

		#region 构造方法

		public AliasAttribute(string alias)
		{
			_alias = alias ?? string.Empty;
		}

		#endregion

		#region 公共属性

		public string Alias
		{
			get
			{
				return _alias;
			}
		}

		#endregion
	}
}