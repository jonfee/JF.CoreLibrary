using System;
using System.Collections.Generic;

namespace JF.Events
{
	/// <summary>
	/// 表示实现该接口的类型为事件聚合器。
	/// </summary>
	public interface IEventAggregator
	{
		void Subscribe<TEvent>(IEventHandler handler) where TEvent : class, IEvent;
		void Subscribe<TEvent>(IEnumerable<IEventHandler> handlers) where TEvent : class, IEvent;
		void Subscribe<TEvent>(params IEventHandler[] handlers) where TEvent : class, IEvent;
		
		void Unsubscribe<TEvent>(IEventHandler handler) where TEvent : class, IEvent;
		void Unsubscribe<TEvent>(IEnumerable<IEventHandler> handlers) where TEvent : class, IEvent;
		void Unsubscribe<TEvent>(params IEventHandler[] handlers) where TEvent : class, IEvent;
		void UnsubscribeAll<TEvent>() where TEvent : class, IEvent;
		void UnsubscribeAll();
		
		IEnumerable<IEventHandler> GetSubscriptions<TEvent>() where TEvent : class, IEvent;
		
		void Publish<TEvent>(TEvent @event) where TEvent : class, IEvent;
		void Publish<TEvent>(TEvent @event, Action<TEvent, bool, Exception> callback, TimeSpan? timeout = null) where TEvent : class, IEvent;
	}
}