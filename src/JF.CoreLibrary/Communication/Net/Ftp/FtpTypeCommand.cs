using System;
using System.Collections.Generic;

namespace JF.Communication.Net.Ftp
{
	/// <summary>
	/// 数据类型（A=ASCII，E=EBCDIC，I=Binary）
	/// </summary>
	internal class FtpTypeCommand : FtpCommand
	{
		public FtpTypeCommand() : base("TYPE")
		{
		}

		protected override object OnExecute(FtpCommandContext context)
		{
			context.Channel.CheckLogin();

			if(string.IsNullOrEmpty(context.Statement.Argument))
			{
				throw new SyntaxException();
			}

			string message = null;

			var arg = context.Statement.Argument.ToUpper();
			if(arg == "A")
			{
				context.Channel.TransferMode = FtpTransferMode.Ascii;
				message = "200 ASCII transfer mode active.";
				context.Channel.Send(message);
			}
			else if(arg == "I")
			{
				context.Channel.TransferMode = FtpTransferMode.Binary;
				message = "200 Binary transfer mode active.";
				context.Channel.Send(message);
			}
			else
			{
				throw new UnknownTransferModeException();
			}

			return message;
		}
	}
}