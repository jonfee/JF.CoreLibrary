using System;
using System.Collections.Generic;

namespace JF.Options
{
	[AttributeUsage(AttributeTargets.Class, Inherited = true)]
	public class OptionLoaderAttribute : Attribute
	{
		#region 成员字段

		private Type _loaderType;

		#endregion

		#region 公共属性

		public Type LoaderType
		{
			get
			{
				return _loaderType;
			}
			set
			{
				_loaderType = value;
			}
		}

		#endregion
	}
}