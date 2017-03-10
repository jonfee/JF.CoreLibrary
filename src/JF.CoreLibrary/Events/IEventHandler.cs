using System;
using System.Collections.Generic;

namespace JF.Events
{
	/// <summary>
	/// 表示实现该接口的类型为事件处理程序。
	/// </summary>
	public interface IEventHandler
	{
		#region 属性定义

		/// <summary>
		/// 获取当前事件处理程序支持的所能处理的事件列表。
		/// </summary>
		IEnumerable<Type> CanHandledEventTypes
		{
			get;
		}

		#endregion

		#region 方法定义

		/// <summary>
		/// 判断当前事件处理程序是否支持处理指定的事件类型。
		/// </summary>
		/// <param name="eventType">要判断的事件类型。</param>
		/// <returns>支持指定的事件类型则返回真(True)，否则返回假(False)。</returns>
		bool CanHandle(Type eventType);

		/// <summary>
		/// 处理给定的事件。
		/// </summary>
		/// <param name="event">需要处理的事件。</param>
		void Handle(IEvent @event);

		#endregion
	}
}
