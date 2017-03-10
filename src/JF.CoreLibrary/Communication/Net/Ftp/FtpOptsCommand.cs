using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JF.Communication.Net.Ftp
{
	/// <summary>
	/// 设置选项参数
	/// </summary>
	internal class FtpOptsCommand : FtpCommand
	{
		public FtpOptsCommand() : base("OPTS")
		{
		}

		protected override object OnExecute(FtpCommandContext context)
		{
			context.Channel.CheckLogin();

			if(string.IsNullOrEmpty(context.Statement.Argument))
			{
				throw new SyntaxException();
			}

			var args = context.Statement.Argument;
			string message;

			if(args.Equals("UTF8 ON", StringComparison.OrdinalIgnoreCase))
			{
				context.Channel.Encoding = Encoding.UTF8;
				message = "200 UTF enabled mode.";
			}
			else if(args.Equals("UTF8 OFF", StringComparison.OrdinalIgnoreCase))
			{
				context.Channel.Encoding = Encoding.ASCII;
				message = "200 ASCII enabled mode.";
			}
			else
			{
				throw new SyntaxException();
			}

			context.Channel.Send(message);

			return message;
		}
	}
}