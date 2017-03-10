using System;
using System.Collections.Generic;
using System.Linq;
using JF.Common;

namespace JF.Events
{
	public abstract class EventHandlerBase : IEventHandler
	{
		#region 成员字段

		private readonly List<Type> _canHandledEventTypes;

		#endregion

		#region 公共属性

		public IEnumerable<Type> CanHandledEventTypes
		{
			get
			{
				return _canHandledEventTypes;
			}
		}

		#endregion

		#region 构造方法

		protected EventHandlerBase(params Type[] canHandledEventTypes)
		{
			if(canHandledEventTypes == null || canHandledEventTypes.Length <= 0)
				throw new ArgumentNullException(nameof(canHandledEventTypes));

			_canHandledEventTypes = new List<Type>();

			foreach(var eventType in canHandledEventTypes)
			{
				if(!TypeExtensions.IsAssignableFrom(typeof(IEvent), eventType))
					throw new ArgumentException();

				_canHandledEventTypes.Add(eventType);
			}
		}

		#endregion

		#region 虚拟方法

		public virtual bool CanHandle(Type eventType)
		{
			if(eventType == null)
				throw new ArgumentNullException(nameof(eventType));

			return _canHandledEventTypes.Any(type => type == eventType);
		}

		#endregion

		#region 抽象方法

		public abstract void Handle(IEvent @event);

		#endregion
	}
}
