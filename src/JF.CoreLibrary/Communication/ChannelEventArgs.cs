using System;
using System.Collections.Generic;

namespace JF.Communication
{
	[Serializable]
	public class ChannelEventArgs : EventArgs
	{
		#region 成员字段

		private IChannel _channel;

		#endregion

		#region 构造方法

		public ChannelEventArgs(IChannel channel)
		{
			if(channel == null)
			{
				throw new ArgumentNullException("channel");
			}

			_channel = channel;
		}

		#endregion

		#region 公共属性

		public IChannel Channel
		{
			get
			{
				return _channel;
			}
			protected set
			{
				_channel = value;
			}
		}

		#endregion
	}
}