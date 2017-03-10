using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JF.Communication.Net.Ftp
{
	/// <summary>
	/// 返回服务器使用的操作系统，指令的回应是该系统当前版本名的第一个单词
	/// </summary>
	internal class FtpSystCommand : FtpCommand
	{
		public FtpSystCommand() : base("SYST")
		{
		}

		protected override object OnExecute(FtpCommandContext context)
		{
			const string MESSAGE = "215 UNIX emulated by JF.FtpServer";

			context.Channel.CheckLogin();

			context.Channel.Send(MESSAGE);

			return MESSAGE;
		}
	}
}