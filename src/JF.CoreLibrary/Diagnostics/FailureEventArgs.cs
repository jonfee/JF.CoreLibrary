using System;

namespace JF.Diagnostics
{
	[Serializable]
	public class FailureEventArgs : EventArgs
	{
		#region 成员字段

		private Exception _exception;
		private bool _exceptionHandled;

		#endregion

		#region 构造方法

		public FailureEventArgs(Exception exception) : this(exception, false)
		{
		}

		public FailureEventArgs(Exception exception, bool exceptionHandled)
		{
			_exception = exception;
			_exceptionHandled = exceptionHandled;
		}

		#endregion

		#region 公共属性

		public Exception Exception
		{
			get
			{
				return _exception;
			}
		}

		public bool ExceptionHandled
		{
			get
			{
				return _exceptionHandled;
			}
			set
			{
				_exceptionHandled = value;
			}
		}

		#endregion
	}
}