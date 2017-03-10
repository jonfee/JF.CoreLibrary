using System;
using System.ComponentModel;

namespace JF.Terminals.Commands
{
	[DisplayName("${ClearCommand.Title}")]
	[Description("${ClearCommand.Description}")]
	public class ClearCommand : JF.Services.CommandBase<TerminalCommandContext>
	{
		#region 构造方法

		public ClearCommand() : base("Clear")
		{
		}

		public ClearCommand(string name) : base(name)
		{
		}

		#endregion

		#region 重写方法

		protected override object OnExecute(TerminalCommandContext context)
		{
			//清空当前终端的显示缓存
			context.Terminal.Clear();

			return null;
		}

		#endregion
	}
}