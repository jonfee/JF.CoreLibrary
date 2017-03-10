using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JF.Communication.Net.Ftp
{
	/// <summary>
	/// 从服务器上复制（下载）文件
	/// </summary>
	internal class FtpRetrCommand : FtpCommand
	{
		public FtpRetrCommand() : base("RETR")
		{
		}

		protected override object OnExecute(FtpCommandContext context)
		{
			context.Channel.CheckLogin();

			if(string.IsNullOrEmpty(context.Statement.Argument))
			{
				throw new SyntaxException();
			}

			context.Channel.CheckDataChannel();

			try
			{
				//context.Channel.Status = FtpSessionStatus.Download;

				var path = context.Statement.Argument;
				string localPath = context.Channel.MapVirtualPathToLocalPath(path);
				context.Statement.Result = localPath;

				var fileInfo = new FileInfo(localPath);

				if(!fileInfo.Exists)
				{
					throw new FileNotFoundException(path);
				}

				var message = "150 Open data connection for file transfer.";

				if(context.Channel.DataChannel.SendFile(fileInfo, context.Channel.FileOffset))
				{
					message = "226 Transfer complete.";
				}
				else
				{
					message = "426 Connection closed; transfer aborted.";
				}

				context.Channel.Send(message);
				context.Channel.FileOffset = 0;

				return message;
			}
			catch(FtpException)
			{
				throw;
			}
			catch(Exception e)
			{
				throw new InternalException(e.Message);
			}
			finally
			{
				context.Channel.CloseDataChannel();
				//context.Channel.Status = FtpSessionStatus.Wait;
			}
		}
	}
}