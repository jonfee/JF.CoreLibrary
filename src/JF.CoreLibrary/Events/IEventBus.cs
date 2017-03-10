using System;
using System.Collections.Generic;

using JF.Common;

namespace JF.Events
{
	/// <summary>
	/// 表示事件总线。
	/// </summary>
	public interface IEventBus : IUnitOfWork
	{
		#region 属性定义

		/// <summary>
		/// 唯一标识符。
		/// </summary>
		Guid ID
		{
			get;
		}

		#endregion

		#region 方法定义

		/// <summary>
		/// 发布指定的事件。
		/// </summary>
		/// <typeparam name="TEvent">事件类型。</typeparam>
		/// <param name="event">需要发布的事件实例。</param>
		void Publish<TEvent>(TEvent @event) where TEvent : class, IEvent;

		/// <summary>
		/// 发布指定的事件集合。
		/// </summary>
		/// <typeparam name="TEvent">事件类型。</typeparam>
		/// <param name="events">需要发布的消息实例集合。</param>
		void Publish<TEvent>(IEnumerable<TEvent> events) where TEvent : class, IEvent;

		/// <summary>
		/// 清除等待提交的事件。
		/// </summary>
		void Clear();

		#endregion
	}
}
