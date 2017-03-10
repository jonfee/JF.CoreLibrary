using System;
using System.Collections.Generic;

namespace JF.Push
{
	public class PushException : Exception
	{
		public PushException(string message) : base(message)
		{

		}

		public PushException(string message, Exception innerException) : base(message, innerException)
		{

		}
	}
}
