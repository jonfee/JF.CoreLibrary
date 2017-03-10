using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JF.Communication.Net.Ftp
{
	/// <summary>
	/// 查询当前支持的扩展命令
	/// </summary>
	internal class FtpFeatCommand : FtpCommand
	{
		public FtpFeatCommand() : base("FEAT")
		{
		}

		protected override object OnExecute(FtpCommandContext context)
		{
			const string MESSAGE = @"211-Features:
 MDTM
 SIZE
 PASV
 UTF8
 HELP
 MFMT
 MLST size*;type*;perm*;create*;modify*;
 MLSD
 REST
 OPTS
 NOOP
211 End";
			context.Channel.Send(MESSAGE);

			return MESSAGE;
		}
	}
}