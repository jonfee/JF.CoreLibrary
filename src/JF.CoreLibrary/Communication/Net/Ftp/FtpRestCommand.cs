using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JF.Communication.Net.Ftp
{
	internal class FtpRestCommand : FtpCommand
	{
		public FtpRestCommand() : base("REST")
		{
		}

		protected override object OnExecute(FtpCommandContext context)
		{
			context.Channel.CheckLogin();

			long offset;
			if(!long.TryParse(context.Statement.Argument, out offset))
			{
				throw new SyntaxException();
			}

			context.Channel.FileOffset = offset;

			var message = string.Format("350 Restarting at {0}. Send STORE or RETR to initiate transfer.", offset);

			context.Channel.Send(message);

			return message;
		}
	}
}