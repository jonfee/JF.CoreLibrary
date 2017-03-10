using System;

namespace JF.Services
{
	[Serializable]
	public class CommandExecutorExecutingEventArgs : CommandExecutorEventArgs
	{
		#region 成员字段

		private bool _cancel;

		#endregion

		#region 构造方法

		public CommandExecutorExecutingEventArgs(CommandExecutorContext context, bool cancel = false) : base(context, null)
		{
			_cancel = cancel;
		}

		#endregion

		#region 公共属性

		public bool Cancel
		{
			get
			{
				return _cancel;
			}
			set
			{
				_cancel = value;
			}
		}

		#endregion
	}
}