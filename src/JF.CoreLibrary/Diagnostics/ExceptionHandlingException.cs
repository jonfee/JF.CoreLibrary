using System;
using System.Collections.Generic;

namespace JF.Diagnostics
{
	/// <summary>
	/// 异常处理失败时引发的异常。
	/// </summary>
	[Serializable]
	public class ExceptionHandlingException : ApplicationException
	{
		#region 构造方法

		public ExceptionHandlingException() : this(string.Empty, null)
		{
		}

		public ExceptionHandlingException(string message) : this(message, null)
		{
		}

		public ExceptionHandlingException(string message, Exception innerException) : base(message, innerException)
		{
		}

		#endregion
	}
}