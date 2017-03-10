using System;
using System.Collections.Generic;

namespace JF.Communication.Net.Ftp
{
	/// <summary>
	/// 放弃此前的FTP服务指令，和任何相关的数据传输。
	/// </summary>
	internal class FtpAborCommand : FtpCommand
	{
		public FtpAborCommand() : base("ABOR")
		{
		}

		protected override object OnExecute(FtpCommandContext context)
		{
			const string MESSAGE = "226 Data connection closed.";

			context.Channel.CheckLogin();
			context.Channel.CloseDataChannel();
			context.Channel.Send(MESSAGE);

			return MESSAGE;
		}
	}
}