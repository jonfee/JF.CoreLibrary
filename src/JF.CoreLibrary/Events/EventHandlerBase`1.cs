using System;
using System.Collections.Generic;

namespace JF.Events
{
	public abstract class EventHandlerBase<TEvent> : EventHandlerBase, IEventHandler<TEvent> where TEvent : class, IEvent
	{
		#region 构造方法

		protected EventHandlerBase() : base(typeof(TEvent))
		{

		}

		#endregion

		#region 抽象方法

		public abstract void Handle(TEvent @event);

		#endregion

		#region 接口实现

		public override void Handle(IEvent @event)
		{
			var targetEvent = JF.Common.Convert.ConvertValue<TEvent>(@event);

			if(targetEvent == null)
				throw new ArgumentException();

			this.Handle(targetEvent);
		}

		#endregion
	}
}
