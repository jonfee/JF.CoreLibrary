using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JF.Communication.Net.Ftp
{
	/// <summary>
	/// 删除服务器上指定的文件
	/// </summary>
	internal class FtpDeleCommand : FtpCommand
	{
		public FtpDeleCommand() : base("DELE")
		{
		}

		protected override object OnExecute(FtpCommandContext context)
		{
			const string MESSAGE = "250 Deleted file successfully.";

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
				throw new FileNotFoundException(path);
			}

			try
			{
				File.Delete(localPath);
			}
			catch(Exception)
			{
				throw new InternalException("delete file");
			}

			context.Channel.Send(MESSAGE);

			return MESSAGE;
		}
	}
}