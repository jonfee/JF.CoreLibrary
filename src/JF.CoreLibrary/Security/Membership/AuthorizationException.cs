using System;
using System.Runtime.Serialization;

namespace JF.Security.Membership
{
	/// <summary>
	/// 授权验证失败时引发的异常。
	/// </summary>
	[Serializable]
	public class AuthorizationException : ApplicationException
	{
		#region 成员字段

		private string _message;

		#endregion

		#region 构造方法

		public AuthorizationException()
		{
			_message = Resources.ResourceUtility.GetString("Text.AuthorizationException.Message");
		}

		public AuthorizationException(string message) : base(message, null)
		{
			_message = string.IsNullOrEmpty(message) ? Resources.ResourceUtility.GetString("Text.AuthorizationException.Message") : message;
		}

		public AuthorizationException(string message, Exception innerException) : base(message, innerException)
		{
			_message = string.IsNullOrEmpty(message) ? Resources.ResourceUtility.GetString("Text.AuthorizationException.Message") : message;
		}

		protected AuthorizationException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		#endregion

		#region 重写属性

		public override string Message
		{
			get
			{
				return _message;
			}
		}

		#endregion

		#region 重写方法

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);
		}

		#endregion
	}
}