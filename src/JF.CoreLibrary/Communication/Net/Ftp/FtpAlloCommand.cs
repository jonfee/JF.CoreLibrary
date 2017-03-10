using System;
using System.Collections.Generic;

namespace JF.Communication.Net.Ftp
{
	internal class FtpAlloCommand : FtpCommand
	{
		public FtpAlloCommand() : base("ALLO")
		{
		}

		protected override object OnExecute(FtpCommandContext context)
		{
			const string MESSAGE = "200 ALLO Command Successful.";

			context.Channel.CheckLogin();

			context.Channel.Send(MESSAGE);

			return MESSAGE;
		}
	}
}