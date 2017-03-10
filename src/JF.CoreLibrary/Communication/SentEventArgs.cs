using System;
using System.Collections.Generic;

namespace JF.Communication
{
	[Serializable]
	public class SentEventArgs : ChannelAsyncEventArgs
	{
		#region 构造方法

		public SentEventArgs(IChannel channel) : this(channel, null)
		{
		}

		public SentEventArgs(IChannel channel, object asyncState) : base(channel, asyncState)
		{
		}

		#endregion
	}
}