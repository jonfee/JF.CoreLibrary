using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JF.Communication.Net.Ftp
{
	/// <summary>
	/// 获取当前工作目录
	/// </summary>
	internal class FtpPwdCommand : FtpCommand
	{
		public FtpPwdCommand() : base("PWD")
		{
		}

		protected override object OnExecute(FtpCommandContext context)
		{
			context.Channel.CheckLogin();

			var message = string.Format("257 \"{0}\" is current directory.", context.Channel.CurrentDir);

			context.Channel.Send(message);

			context.Statement.Result = context.Channel.MapVirtualPathToLocalPath(context.Channel.CurrentDir);

			return message;
		}
	}
}