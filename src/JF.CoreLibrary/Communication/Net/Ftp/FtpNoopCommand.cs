using System;
using System.Collections.Generic;

namespace JF.Communication.Net.Ftp
{
	internal class FtpNoopCommand : FtpCommand
	{
		public FtpNoopCommand() : base("NOOP")
		{
		}

		protected override object OnExecute(FtpCommandContext context)
		{
			const string MESSAGE = "200 NOOP Command Successful.";

			context.Channel.CheckLogin();
			context.Channel.Send(MESSAGE);
			return MESSAGE;
		}
	}
}