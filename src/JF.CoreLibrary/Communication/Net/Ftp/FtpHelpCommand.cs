using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JF.Communication.Net.Ftp
{
	/// <summary>
	/// 返回帮助信息，打印出当前支持的所有命令
	/// </summary>
	internal class FtpHelpCommand : FtpCommand
	{
		public FtpHelpCommand() : base("HELP")
		{
		}

		protected override object OnExecute(FtpCommandContext context)
		{
			string message;

			if(string.IsNullOrEmpty(context.Statement.Argument))
			{
				var cmd = context.Statement.Argument;

				if(context.Executor.Root.Children.Contains(cmd))
				{
					message = string.Format("214 Command {0} is supported by Ftp Server", cmd.ToUpper());
				}
				else
				{
					message = string.Format("502 Command {0} is not recognized or supported by Ftp Server", cmd.ToUpper());
				}
			}
			else
			{
				var cmds = context.Executor.Root.Children.Keys.ToArray();

				var text = new StringBuilder();
				text.Append("214-The following commands are recognized:");

				for(int i = 0; i < cmds.Length; i++)
				{
					if(i % 8 == 0)
					{
						text.Append("\r\n");
					}

					text.AppendFormat("    {0}", cmds[i]);
				}

				message = text.ToString();
			}

			context.Channel.Send(message);

			return message;
		}
	}
}