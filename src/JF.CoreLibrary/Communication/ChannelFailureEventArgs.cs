using System;
using System.Collections.Generic;

namespace JF.Communication
{
	public class ChannelFailureEventArgs : ChannelAsyncEventArgs
	{
		#region 成员字段

		private string _message;
		private Exception _exception;

		#endregion

		#region 构造方法

		public ChannelFailureEventArgs(IChannel channel, string message) : this(channel, message, null)
		{
		}

		public ChannelFailureEventArgs(IChannel channel, string message, object asyncState) : base(channel, asyncState)
		{
			_message = message;
		}

		public ChannelFailureEventArgs(IChannel channel, Exception exception) : this(channel, exception, null)
		{
		}

		public ChannelFailureEventArgs(IChannel channel, Exception exception, object asyncState) : base(channel, asyncState)
		{
			_exception = exception;
		}

		#endregion

		#region 公共属性

		public string Message
		{
			get
			{
				if(string.IsNullOrEmpty(_message) && _exception != null)
				{
					return _exception.Message;
				}

				return _message;
			}
		}

		public Exception Exception
		{
			get
			{
				return _exception;
			}
		}

		#endregion
	}
}