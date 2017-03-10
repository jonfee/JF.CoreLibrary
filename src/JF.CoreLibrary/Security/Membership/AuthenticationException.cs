using System;
using System.Runtime.Serialization;

namespace JF.Security.Membership
{
	/// <summary>
	/// 身份验证失败时引发的异常。
	/// </summary>
	[Serializable]
	public class AuthenticationException : System.ApplicationException
	{
		#region 成员字段

		private AuthenticationReason _reason;
		private string _message;

		#endregion

		#region 构造方法

		public AuthenticationException()
		{
			_message = this.GetMessage(null);
		}

		public AuthenticationException(string message) : base(message, null)
		{
			_message = this.GetMessage(message);
		}

		public AuthenticationException(string message, Exception innerException) : base(message, innerException)
		{
			_message = this.GetMessage(message);
		}

		public AuthenticationException(AuthenticationReason reason) : this(reason, string.Empty, null)
		{
		}

		public AuthenticationException(AuthenticationReason reason, string message) : this(reason, message, null)
		{
		}

		public AuthenticationException(AuthenticationReason reason, string message, Exception innerException) : base(message, innerException)
		{
			_reason = reason;
			_message = this.GetMessage(message);
		}

		protected AuthenticationException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_reason = (AuthenticationReason)info.GetInt32("Reason");
		}

		#endregion

		#region 公共属性

		/// <summary>
		/// 获取验证失败的原因。
		/// </summary>
		public AuthenticationReason Reason
		{
			get
			{
				return _reason;
			}
		}

		public override string Message
		{
			get
			{
				return _message;
			}
		}

		#endregion

		#region 重写方法

		public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			base.GetObjectData(info, context);
			info.AddValue("Reason", _reason);
		}

		#endregion

		#region 私有方法

		private string GetMessage(string message)
		{
			if(string.IsNullOrWhiteSpace(message))
			{
				var entry = JF.Common.EnumUtility.GetEnumEntry(_reason);

				if(entry != null)
				{
					return entry.Description;
				}
			}

			return message;
		}

		#endregion
	}
}