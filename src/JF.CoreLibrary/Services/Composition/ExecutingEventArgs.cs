using System;
using System.Collections.Generic;

namespace JF.Services.Composition
{
	public class ExecutingEventArgs : ExecutionEventArgs<IExecutionContext>
	{
		#region 成员字段

		private bool _cancel;

		#endregion

		#region 构造方法

		public ExecutingEventArgs(IExecutionContext context, bool cancel = false) : base(context)
		{
			_cancel = cancel;
		}

		#endregion

		#region 公共属性

		public bool Cancel
		{
			get
			{
				return _cancel;
			}
			set
			{
				_cancel = value;
			}
		}

		#endregion
	}
}