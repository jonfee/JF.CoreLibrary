using System;
using System.Runtime.Serialization;

namespace JF.Security
{
	[Serializable]
	public class CensorshipException : ApplicationException
	{
		#region 构造方法

		public CensorshipException()
		{
		}

		public CensorshipException(string message) : this(message, null)
		{
		}

		public CensorshipException(string message, Exception innerException) : base(message, innerException)
		{
		}

		#endregion
	}
}