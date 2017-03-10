using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JF.Communication.Net.Ftp
{
	/// <summary>
	/// 对上一次的“重命名(RNFR)”指令提到的文件重命名
	/// </summary>
	internal class FtpRntoCommand : FtpCommand
	{
		public FtpRntoCommand() : base("RNTO")
		{
		}

		protected override object OnExecute(FtpCommandContext context)
		{
			const string MESSAGE = "250 Rename successful.";

			context.Channel.CheckLogin();

			try
			{
				if(string.IsNullOrEmpty(context.Statement.Argument))
				{
					throw new SyntaxException();
				}

				if(string.IsNullOrEmpty(context.Channel.RenamePath))
				{
					throw new BadSeqCommandsException();
				}

				string destPath = context.Channel.MapVirtualPathToLocalPath(context.Statement.Argument);
				context.Statement.Result = destPath;

				try
				{
					if(Directory.Exists(context.Channel.RenamePath))
					{
						Directory.Move(context.Channel.RenamePath, destPath);
					}
					else
					{
						File.Move(context.Channel.RenamePath, destPath);
					}
				}
				catch(Exception)
				{
					throw new InternalException("rename path");
				}

				context.Channel.Send(MESSAGE);
				return MESSAGE;
			}
			finally
			{
				context.Channel.RenamePath = null;
			}
		}
	}
}