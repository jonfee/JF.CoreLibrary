using System;
using System.Collections.Generic;

namespace JF.Communication.Net.Ftp
{
	/// <summary>
	/// 登录密码
	/// </summary>
	internal class FtpPassCommand : FtpCommand
	{
		public FtpPassCommand() : base("PASS")
		{
		}

		protected override object OnExecute(FtpCommandContext context)
		{
			var user = context.Server.Configuration.Users[context.Channel.UserName];

			if(user != null)
			{
				if(string.Equals(context.Statement.Argument, user.Password, StringComparison.OrdinalIgnoreCase))
				{
					context.Channel.User = user;
					context.Channel.Send("230 User successfully logged in.", null);
					context.Statement.Result = true;
					return true;
				}
			}

			context.Channel.Send("530 Not logged in, user or password incorrect!", null);
			context.Statement.Result = false;
			return false;
		}
	}
}