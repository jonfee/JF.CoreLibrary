using System;
using System.IO;
using System.Collections.Generic;

namespace JF.Communication.Net.Ftp
{
	/// <summary>
	/// 修改服务器上的文件的最后修改时间（GMT）
	/// </summary>
	internal class FtpMfmtCommand : FtpCommand
	{
		public FtpMfmtCommand() : base("MFMT")
		{
		}

		protected override object OnExecute(FtpCommandContext context)
		{
			const string MESSAGE = "213 Date/time changed OK.";

			context.Channel.CheckLogin();

			try
			{
				if(string.IsNullOrWhiteSpace(context.Statement.Argument))
				{
					throw new SyntaxException();
				}

				var arguments = context.Statement.Argument.Split(new[]
				{
					' '
				}, 2);
				if(arguments.Length != 2)
				{
					throw new SyntaxException();
				}

				var dateTime = FtpDateUtils.ParseFtpDate(arguments[0]);
				var filePath = context.Channel.MapVirtualPathToLocalPath(arguments[1]);

				var fileInfo = new FileInfo(filePath);
				if(!fileInfo.Exists)
				{
					throw new FileNotFoundException(arguments[1]);
				}

				fileInfo.LastWriteTimeUtc = dateTime;

				context.Channel.Send(MESSAGE);

				return MESSAGE;
			}
			catch(FtpException)
			{
				throw;
			}
			catch(Exception)
			{
				throw new InternalException("");
			}
		}
	}
}