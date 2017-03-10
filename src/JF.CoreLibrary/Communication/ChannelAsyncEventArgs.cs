using System;
using System.Collections.Generic;

namespace JF.Communication
{
	[Serializable]
	public class ChannelAsyncEventArgs : ChannelEventArgs
	{
		#region 成员字段

		private object _asyncState;

		#endregion

		#region 构造方法

		public ChannelAsyncEventArgs(IChannel channel) : base(channel)
		{
			_asyncState = null;
		}

		public ChannelAsyncEventArgs(IChannel channel, object asyncState) : base(channel)
		{
			_asyncState = asyncState;
		}

		#endregion

		#region 公共属性

		public object AsyncState
		{
			get
			{
				return _asyncState;
			}
		}

		#endregion
	}
}