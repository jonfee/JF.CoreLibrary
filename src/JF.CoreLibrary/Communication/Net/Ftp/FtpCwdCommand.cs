using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JF.Communication.Net.Ftp
{
	/// <summary>
	/// 改变工作目录
	/// </summary>
	internal class FtpCwdCommand : FtpCommand
	{
		public FtpCwdCommand() : base("CWD")
		{
		}

		protected override object OnExecute(FtpCommandContext context)
		{
			context.Channel.CheckLogin();

			if(string.IsNullOrEmpty(context.Statement.Argument))
			{
				throw new SyntaxException();
			}

			var changeDir = context.Statement.Argument;

			var path = context.Channel.MapVirtualPathToLocalPath(changeDir);

			if(File.Exists(path) || !Directory.Exists(path))
			{
				throw new DirectoryNotFoundException(changeDir);
			}

			context.Statement.Result = path;

			context.Channel.CurrentDir = context.Channel.MapLocalPathToVirtualPath(path);
			var message = string.Format("250 \"{0}\" is current directory.", context.Channel.CurrentDir);
			context.Channel.Send(message);
			return message;
		}
	}
}