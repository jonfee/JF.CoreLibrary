using System;
using System.Collections.Generic;

namespace JF.Services.Composition
{
	public class ExecutionResult
	{
		#region 成员字段

		private IExecutionContext _context;

		#endregion

		#region 构造方法

		public ExecutionResult(IExecutionContext context)
		{
			if(context == null)
			{
				throw new ArgumentNullException("context");
			}

			_context = context;
		}

		#endregion

		#region 公共属性

		public object Result
		{
			get
			{
				return _context.Result;
			}
		}

		public Exception Exception
		{
			get
			{
				return _context.Exception;
			}
		}

		public IExecutionContext Context
		{
			get
			{
				return _context;
			}
		}

		#endregion
	}
}