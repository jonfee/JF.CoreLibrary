using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JF.Communication.Net.Ftp
{
	/// <summary>
	/// 在服务器上建立指定目录
	/// </summary>
	internal class FtpMkdCommand : FtpCommand
	{
		public FtpMkdCommand() : base("MKD")
		{
		}

		protected override object OnExecute(FtpCommandContext context)
		{
			const string MESSAGE = "257 Created directory successfully.";

			context.Channel.CheckLogin();

			if(string.IsNullOrEmpty(context.Statement.Argument))
			{
				throw new SyntaxException();
			}

			var path = context.Statement.Argument;
			var localPath = context.Channel.MapVirtualPathToLocalPath(path);
			context.Statement.Result = localPath;

			if(File.Exists(localPath))
			{
				throw new DirectoryNotFoundException(path);
			}

			try
			{
				Directory.CreateDirectory(localPath);
			}
			catch(Exception)
			{
				throw new InternalException("create dir");
			}

			context.Channel.Send(MESSAGE);

			return MESSAGE;
		}
	}
}