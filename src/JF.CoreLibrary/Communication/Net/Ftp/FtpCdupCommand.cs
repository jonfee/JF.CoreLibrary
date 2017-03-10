using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JF.Communication.Net.Ftp
{
	/// <summary>
	/// 回到上一级目录
	/// </summary>
	internal class FtpCdupCommand : FtpCommand
	{
		public FtpCdupCommand() : base("CDUP")
		{
		}

		protected override object OnExecute(FtpCommandContext context)
		{
			context.Channel.CheckLogin();

			var localPath = context.Channel.MapVirtualPathToLocalPath("..");
			context.Statement.Result = localPath;
			var virtualPath = context.Channel.MapLocalPathToVirtualPath(localPath);

			if(Directory.Exists(localPath))
			{
				context.Channel.CurrentDir = virtualPath;
				context.Channel.Send($"250 the '{context.Channel.CurrentDir}' is current directory.");
				return $"250 the '{context.Channel.CurrentDir}' is current directory.";
			}

			throw new DirectoryNotFoundException(virtualPath);
		}
	}
}