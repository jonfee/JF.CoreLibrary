using System;
using System.ComponentModel;

namespace JF.Communication
{
	public interface IChannel : IReceiver, ISender, IDisposable
	{
		#region 事件定义

		event EventHandler<ChannelEventArgs> Closed;

		event EventHandler<ChannelEventArgs> Closing;

		#endregion

		#region 属性定义

		int ChannelId
		{
			get;
		}

		bool IsIdled
		{
			get;
		}

		DateTime LastSendTime
		{
			get;
		}

		DateTime LastReceivedTime
		{
			get;
		}

		#endregion

		#region 方法定义

		void Close();

		#endregion
	}
}