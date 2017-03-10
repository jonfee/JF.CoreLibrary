using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace JF.Services
{
	[Serializable]
	public class CommandException : ApplicationException
	{
		#region 成员字段

		private int _code;

		#endregion

		#region 构造方法

		public CommandException()
		{
			_code = 0;
		}

		public CommandException(string message) : this(0, message, null)
		{
		}

		public CommandException(string message, Exception innerException) : this(0, message, innerException)
		{
		}

		public CommandException(int code, string message) : this(code, message, null)
		{
		}

		public CommandException(int code, string message, Exception innerException) : base(message, innerException)
		{
			_code = code;
		}

		protected CommandException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_code = info.GetInt32("Code");
		}

		#endregion

		#region 公共属性

		public int Code
		{
			get
			{
				return _code;
			}
		}

		#endregion

		#region 重写方法

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			//调用基类同名方法
			base.GetObjectData(info, context);

			//将定义的属性值加入持久化信息集中
			info.AddValue("Code", _code);
		}

		#endregion
	}
}