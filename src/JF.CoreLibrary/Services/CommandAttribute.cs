using System;

namespace JF.Services
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class CommandAttribute : Attribute
	{
		#region 成员字段

		private bool _ignoreOptions;

		#endregion

		#region 构造方法

		public CommandAttribute()
		{
		}

		public CommandAttribute(bool ignoreOptions)
		{
			_ignoreOptions = ignoreOptions;
		}

		#endregion

		#region 公共属性

		/// <summary>
		/// 获取或设置是否忽略验证传入的命令选项是否合法，默认值为假(False)。
		/// </summary>
		public bool IgnoreOptions
		{
			get
			{
				return _ignoreOptions;
			}
			set
			{
				_ignoreOptions = value;
			}
		}

		#endregion
	}
}