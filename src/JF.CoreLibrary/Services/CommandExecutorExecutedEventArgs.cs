using System;

namespace JF.Services
{
	[Serializable]
	public class CommandExecutorExecutedEventArgs : CommandExecutorEventArgs
	{
		#region 构造方法

		public CommandExecutorExecutedEventArgs(CommandExecutorContext context, object result) : base(context, result)
		{
		}

		#endregion
	}
}