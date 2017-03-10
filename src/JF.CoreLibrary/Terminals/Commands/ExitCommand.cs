using System;
using System.ComponentModel;
using JF.Services;
using JF.Resources;
using JF.Terminals;

namespace JF.Terminals.Commands
{
	[DisplayName("${Text.ExitCommand.Title}")]
	[Description("${Text.ExitCommand.Description}")]
	[CommandOption("yes", Type = null, Description = "${Text.ExitCommand.Options.Confirm}")]
	public class ExitCommand : JF.Services.CommandBase<TerminalCommandContext>
	{
		#region 构造方法

		public ExitCommand() : base("Exit")
		{
		}

		public ExitCommand(string name) : base(name)
		{
		}

		#endregion

		#region 重写方法

		protected override object OnExecute(TerminalCommandContext context)
		{
			if(context.Expression.Options.Contains("yes"))
			{
				throw new TerminalCommandExecutor.ExitException();
			}

			context.Terminal.Write(ResourceUtility.GetString("${Text.ExitCommand.Confirm}"));

			if(string.Equals(context.Terminal.Input.ReadLine().Trim(), "yes", StringComparison.OrdinalIgnoreCase))
			{
				throw new TerminalCommandExecutor.ExitException();
			}

			return null;
		}

		#endregion
	}
}