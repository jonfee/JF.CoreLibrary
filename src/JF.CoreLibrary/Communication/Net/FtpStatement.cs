using System;
using System.Collections.Generic;

namespace JF.Communication.Net
{
	public class FtpStatement
	{
		#region 成员字段

		private string _name;
		private string _argument;
		private object _result;

		#endregion

		#region 构造方法

		internal FtpStatement(string name, string argument)
		{
			_name = name;
			_argument = argument;
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

		public string Argument
		{
			get
			{
				return _argument;
			}
		}

		public object Result
		{
			get
			{
				return _result;
			}
			internal set
			{
				_result = value;
			}
		}

		#endregion
	}
}