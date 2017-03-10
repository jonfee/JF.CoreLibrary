using System;
using System.Runtime.Serialization;

namespace JF.Services
{
	[Serializable]
	public class CommandExpressionException : ApplicationException
	{
		#region 构造方法

		public CommandExpressionException()
		{
		}

		public CommandExpressionException(string message) : base(message)
		{
		}

		public CommandExpressionException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected CommandExpressionException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		#endregion
	}
}