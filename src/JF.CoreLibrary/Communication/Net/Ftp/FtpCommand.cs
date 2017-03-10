using System;
using System.Collections.Generic;
using JF.Services;
using JF.Services.Composition;

namespace JF.Communication.Net.Ftp
{
	internal abstract class FtpCommand : CommandBase<FtpCommandContext>
	{
		#region 构造方法

		protected FtpCommand(string name) : base(name)
		{
		}

		#endregion

		#region 重写方法

		protected override void OnExecuted(CommandExecutedEventArgs e)
		{
			if(e.Exception != null)
			{
				e.ExceptionHandled = (e.Exception is FtpException);

				if(e.ExceptionHandled)
				{
					((FtpCommandContext)e.Context).Channel.Send(e.Exception.ToString());
				}
			}

			base.OnExecuted(e);
		}

		#endregion
	}
}