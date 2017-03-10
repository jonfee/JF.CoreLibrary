using System;
using System.Collections.Generic;
using System.Text;

namespace JF.ComponentModel
{
	public class ApplicationEventArgs : EventArgs
	{
		#region 成员字段

		private string[] _args;
		private ApplicationContextBase _applicationContext;

		#endregion

		#region 构造方法

		public ApplicationEventArgs(ApplicationContextBase applicationContext, string[] args)
		{
			_applicationContext = applicationContext;
			_args = args ?? new string[0];
		}

		#endregion

		#region 公共属性

		public ApplicationContextBase ApplicationContext
		{
			get
			{
				return _applicationContext;
			}
		}

		public string[] Arguments
		{
			get
			{
				return _args;
			}
		}

		#endregion
	}
}