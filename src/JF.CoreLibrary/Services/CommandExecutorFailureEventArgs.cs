using System;

namespace JF.Services
{
	[Serializable]
	public class CommandExecutorFailureEventArgs : JF.Diagnostics.FailureEventArgs
	{
		#region 成员字段

		private CommandExecutorContext _context;

		#endregion

		#region 构造方法

		public CommandExecutorFailureEventArgs(CommandExecutorContext context, Exception exception) : base(exception, false)
		{
			if(context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			_context = context;
		}

		public CommandExecutorFailureEventArgs(CommandExecutorContext context, Exception exception, bool handled) : base(exception, handled)
		{
			if(context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			_context = context;
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

		#endregion
	}
}