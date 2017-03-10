using System;

namespace JF.Communication
{
	public interface IChannelContext : JF.Services.Composition.IExecutionContext
	{
		/// <summary>
		/// 获取当前通讯的<seealso cref="IChannel"/>通道。
		/// </summary>
		IChannel Channel
		{
			get;
		}
	}
}