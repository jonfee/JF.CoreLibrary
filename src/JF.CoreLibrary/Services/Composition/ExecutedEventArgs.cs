using System;
using System.Collections.Generic;

namespace JF.Services.Composition
{
	public class ExecutedEventArgs : ExecutionEventArgs<IExecutionContext>
	{
		#region 构造方法

		public ExecutedEventArgs(IExecutionContext context) : base(context)
		{
		}

		#endregion
	}
}