using System;
using System.Collections.Generic;

namespace JF.Messaging
{
	public class MessageEnqueueSettings
	{
		#region 成员字段

		private TimeSpan _delayTimeout;
		private byte _priority;

		#endregion

		#region 构造方法

		public MessageEnqueueSettings() : this(TimeSpan.Zero)
		{
		}

		public MessageEnqueueSettings(byte priority) : this(TimeSpan.Zero)
		{
		}

		public MessageEnqueueSettings(TimeSpan delayTimeout, byte priority = 6)
		{
			_delayTimeout = delayTimeout;
			_priority = priority;
		}

		#endregion

		#region 公共属性

		public TimeSpan DelayTimeout
		{
			get
			{
				return _delayTimeout;
			}
			set
			{
				_delayTimeout = value;
			}
		}

		public byte Priority
		{
			get
			{
				return _priority;
			}
			set
			{
				_priority = value;
			}
		}

		#endregion
	}
}