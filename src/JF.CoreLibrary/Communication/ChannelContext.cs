using System;
using System.Collections.Generic;
using JF.Services;
using JF.Services.Composition;

namespace JF.Communication
{
	public class ChannelContext : JF.Services.Composition.ExecutionContext, IChannelContext
	{
		#region 成员字段

		private IChannel _channel;

		#endregion

		#region 构造方法

		public ChannelContext(IExecutor executor, object data, IChannel channel) : base(executor, data)
		{
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
		}

		#endregion
	}
}