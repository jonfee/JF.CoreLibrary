using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JF.Services;
using JF.Services.Composition;

namespace JF.Communication.Net.Ftp
{
	/// <summary>
	/// 登录用户名
	/// </summary>
	internal class FtpUserCommand : FtpCommand
	{
		public FtpUserCommand() : base("USER")
		{
		}

		protected override object OnExecute(FtpCommandContext context)
		{
			string result;
			var user = context.Server.Configuration.Users[context.Statement.Argument];

			if(user != null)
			{
				context.Channel.UserName = context.Statement.Argument;

				if(string.IsNullOrEmpty(user.Password))
				{
					context.Channel.User = user;
					result = "230 User successfully logged in.";
					context.Statement.Result = true;
				}
				else
				{
					result = "331 Password required for " + context.Statement.Argument;
					context.Statement.Result = false;
				}
			}
			else
			{
				result = "331 Password required for " + context.Statement.Argument;
				context.Statement.Result = false;
			}

			context.Channel.Send(result);

			return result;
		}
	}
}