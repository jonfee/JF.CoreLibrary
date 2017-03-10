using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JF.Communication.Net.Ftp
{
	/// <summary>
	/// 在服务器上删除指定目录
	/// </summary>
	internal class FtpRmdCommand : FtpCommand
	{
		public FtpRmdCommand() : base("RMD")
		{
		}

		protected override object OnExecute(FtpCommandContext context)
		{
			const string MESSAGE = "250 Deleted directory successfully.";

			context.Channel.CheckLogin();

			if(string.IsNullOrEmpty(context.Statement.Argument))
			{
				throw new SyntaxException();
			}

			var path = context.Statement.Argument;
			var localPath = context.Channel.MapVirtualPathToLocalPath(path);
			context.Statement.Result = localPath;

			if(!Directory.Exists(localPath))
			{
				throw new DirectoryNotFoundException(path);
			}

			try
			{
				Directory.Delete(localPath);
			}
			catch(Exception)
			{
				throw new InternalException("delete dir");
			}

			context.Channel.Send(MESSAGE);
			return MESSAGE;
		}
	}
}