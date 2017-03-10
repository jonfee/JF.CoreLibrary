using System;

namespace JF.Services
{
	[Serializable]
	public class CommandExecutorEventArgs : EventArgs
	{
		#region 成员字段

		private CommandExecutorContext _context;
		private object _result;

		#endregion

		#region 构造方法

		public CommandExecutorEventArgs(CommandExecutorContext context, object result)
		{
			if(context == null)
			{
				throw new ArgumentNullException("context");
			}

			_context = context;
			_result = result;
		}

		#endregion

		#region 公共属性

		public CommandExecutorContext Context
		{
			get
			{
				return _context;
			}
		}

		public object Result
		{
			get
			{
				return _result;
			}
			set
			{
				_result = value;
			}
		}

		#endregion
	}
}