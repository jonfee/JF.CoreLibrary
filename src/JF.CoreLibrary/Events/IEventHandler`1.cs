using System;
using System.Collections.Generic;

namespace JF.Events
{
	/// <summary>
	/// 表示实现该接口的类型为特定类型事件处理程序。
	/// </summary>
	/// <typeparam name="TEvent">事件类型。</typeparam>
	public interface IEventHandler<in TEvent> : IEventHandler where TEvent : IEvent
	{
		/// <summary>
		/// 处理给定的事件。
		/// </summary>
		/// <param name="event">需要处理的事件。</param>
		void Handle(TEvent @event);
	}
}
