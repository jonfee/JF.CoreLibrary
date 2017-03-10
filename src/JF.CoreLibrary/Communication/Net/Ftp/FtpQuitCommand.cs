using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JF.Communication.Net.Ftp
{
	/// <summary>
	/// 退出登录
	/// </summary>
	internal class FtpQuitCommand : FtpCommand
	{
		public FtpQuitCommand() : base("QUIT")
		{
		}

		protected override object OnExecute(FtpCommandContext context)
		{
			context.Channel.Status = FtpSessionStatus.NotLogin;
			context.Channel.User = null;
			context.Channel.Send("221 Bye-bye.");
			context.Channel.Close();

			return "221 Bye-bye.";
		}
	}
}