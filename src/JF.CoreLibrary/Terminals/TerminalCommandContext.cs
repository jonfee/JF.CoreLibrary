using System;
using System.Collections.Generic;
using JF.Services;

namespace JF.Terminals
{
	public class TerminalCommandContext : JF.Services.CommandContext
	{
		#region 构造方法

		public TerminalCommandContext(TerminalCommandExecutor executor, CommandExpression expression, ICommand command, object parameter, IDictionary<string, object> extendedProperties = null) : base(executor, expression, command, parameter, extendedProperties)
		{
		}

		public TerminalCommandContext(TerminalCommandExecutor executor, CommandExpression expression, CommandTreeNode commandNode, object parameter, IDictionary<string, object> extendedProperties = null) : base(executor, expression, commandNode, parameter, extendedProperties)
		{
		}

		#endregion

		#region 公共属性

		public ITerminal Terminal
		{
			get
			{
				return ((TerminalCommandExecutor)this.Executor).Terminal;
			}
		}

		#endregion
	}
}