using System;
using System.Runtime.Serialization;

namespace JF.Security
{
	public class SecurityException : Exception
	{
		#region 成员字段

		private string _reason;

		#endregion

		#region 构造方法

		public SecurityException()
		{
		}

		public SecurityException(string message) : base(message, null)
		{
		}

		public SecurityException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public SecurityException(string reason, string message) : base(message, null)
		{
			_reason = reason;
		}

		public SecurityException(string reason, string message, Exception innerException) : base(message, innerException)
		{
			_reason = reason;
		}

		protected SecurityException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_reason = info.GetString("Reason");
		}

		#endregion

		#region 重写方法

		public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			base.GetObjectData(info, context);

			info.AddValue("Reason", _reason);
		}

		#endregion
	}
}