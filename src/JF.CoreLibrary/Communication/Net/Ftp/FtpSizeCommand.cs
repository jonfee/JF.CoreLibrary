using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JF.Communication.Net.Ftp
{
	/// <summary>
	/// 查询当前文件的大小
	/// </summary>
	internal class FtpSizeCommand : FtpCommand
	{
		public FtpSizeCommand() : base("SIZE")
		{
		}

		protected override object OnExecute(FtpCommandContext context)
		{
			context.Channel.CheckLogin();

			if(string.IsNullOrEmpty(context.Statement.Argument))
			{
				throw new SyntaxException();
			}

			var file = context.Statement.Argument;
			if(string.IsNullOrEmpty(file))
			{
				throw new SyntaxException();
			}

			string localPath = context.Channel.MapVirtualPathToLocalPath(file);
			try
			{
				long length = 0;
				var info = new FileInfo(localPath);
				if(info.Exists)
				{
					length = info.Length;
				}

				var message = string.Concat("213 ", length.ToString());

				context.Channel.Send(message);

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
		}
	}
}