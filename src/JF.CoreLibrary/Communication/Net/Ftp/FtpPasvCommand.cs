using System;
using System.Collections.Generic;

namespace JF.Communication.Net.Ftp
{
	/// <summary>
	/// 开启被动数据传输模式
	/// </summary>
	internal class FtpPasvCommand : FtpCommand
	{
		public FtpPasvCommand() : base("PASV")
		{
		}

		protected override object OnExecute(FtpCommandContext context)
		{
			context.Channel.CheckLogin();

			context.Channel.CreatePasvDataChannel();

			return true;
		}
	}
}