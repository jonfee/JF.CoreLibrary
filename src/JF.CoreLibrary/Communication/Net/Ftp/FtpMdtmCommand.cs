using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JF.Communication.Net.Ftp
{
	/// <summary>
	/// 返回文件最近修改时间
	/// </summary>
	internal class FtpMdtmCommand : FtpCommand
	{
		public FtpMdtmCommand() : base("MDTM")
		{
		}

		protected override object OnExecute(FtpCommandContext context)
		{
			context.Channel.CheckLogin();

			if(string.IsNullOrEmpty(context.Statement.Argument))
			{
				throw new SyntaxException();
			}

			var path = context.Statement.Argument;
			var localPath = context.Channel.MapVirtualPathToLocalPath(path);
			context.Statement.Result = localPath;

			var info = new FileInfo(localPath);
			if(info.Exists)
			{
				var message = string.Format("213 {0}", FtpDateUtils.FormatFtpDate(info.LastWriteTimeUtc));
				context.Channel.Send(message);
				return message;
			}

			throw new FileNotFoundException(path);
		}
	}
}