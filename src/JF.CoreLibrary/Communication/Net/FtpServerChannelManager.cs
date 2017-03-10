using System;
using System.Collections.Generic;

namespace JF.Communication.Net
{
	public class FtpServerChannelManager : TcpServerChannelManager
	{
		#region 构造方法

		internal FtpServerChannelManager(FtpServer server) : base(server)
		{
		}

		internal FtpServerChannelManager(FtpServer server, IPacketizerFactory packetizerFactory) : base(server, packetizerFactory)
		{
		}

		#endregion

		#region 公共属性

		public new FtpServer Server
		{
			get
			{
				return base.Server as FtpServer;
			}
		}

		#endregion

		#region 重写方法

		protected override TcpServerChannel CreateChannel(int channelId)
		{
			return new FtpServerChannel(this, channelId);
		}

		#endregion
	}
}