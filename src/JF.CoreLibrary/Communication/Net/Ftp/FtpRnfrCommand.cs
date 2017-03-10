using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JF.Communication.Net.Ftp
{
	/// <summary>
	/// 要被改名的文件的旧路径名,此指令必须紧跟一个“重命名为(RTO)”指令来指明新的文件路径名
	/// </summary>
	internal class FtpRnfrCommand : FtpCommand
	{
		public FtpRnfrCommand() : base("RNFR")
		{
		}

		protected override object OnExecute(FtpCommandContext context)
		{
			const string MESSAGE = "350 File or directory exists, ready for destination name.";

			context.Channel.CheckLogin();

			if(string.IsNullOrEmpty(context.Statement.Argument))
			{
				throw new SyntaxException();
			}

			context.Channel.RenamePath = context.Channel.MapVirtualPathToLocalPath(context.Statement.Argument);
			context.Statement.Result = context.Channel.RenamePath;
			context.Channel.Send(MESSAGE);
			return MESSAGE;
		}
	}
}