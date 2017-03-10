using System;
using System.Runtime.Serialization;

namespace JF.IO
{
	[Serializable]
	public class PathException : ApplicationException
	{
		#region 构造方法

		public PathException(string message) : base(message)
		{
		}

		public PathException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected PathException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		#endregion
	}
}