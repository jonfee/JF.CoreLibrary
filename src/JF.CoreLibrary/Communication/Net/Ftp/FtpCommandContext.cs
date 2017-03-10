using System;
using System.Collections.Generic;
using JF.Services;

namespace JF.Communication.Net.Ftp
{
	internal class FtpCommandContext : CommandContext
	{
		#region 私有字段

		private FtpServerChannel _channel;
		private FtpStatement _statement;

		#endregion

		#region 构造方法

		internal FtpCommandContext(ICommandExecutor executor, CommandExpression expression, ICommand command, FtpServerChannel channel, FtpStatement statement) : base(executor, expression, command, null, null)
		{
			_channel = channel;
			_statement = statement;
		}

		#endregion

		#region 公共属性

		public FtpStatement Statement
		{
			get
			{
				return _statement;
			}
		}

		public FtpServer Server
		{
			get
			{
				return ((FtpServerChannelManager)_channel.ChannelManager).Server;
			}
		}

		public FtpServerChannel Channel
		{
			get
			{
				return _channel;
			}
		}

		#endregion
	}
}