using System;
using System.Collections.Generic;

namespace JF.Messaging
{
	public class MessageDequeueSettings
	{
		#region 成员字段

		private TimeSpan _pollingTimeout;

		#endregion

		#region 构造方法

		public MessageDequeueSettings() : this(TimeSpan.Zero)
		{
		}

		public MessageDequeueSettings(TimeSpan pollingTimeout)
		{
			_pollingTimeout = pollingTimeout;
		}

		#endregion

		#region 公共属性

		public TimeSpan PollingTimeout
		{
			get
			{
				return _pollingTimeout;
			}
			set
			{
				_pollingTimeout = value;
			}
		}

		#endregion
	}
}