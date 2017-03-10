using System;
using System.Runtime.Serialization;

namespace JF.Security
{
	/// <summary>
	/// 安全凭证操作相关的异常。
	/// </summary>
	[Serializable]
	public class CredentialException : System.ApplicationException
	{
		#region 成员字段

		private string _credentialId;
		private string _message;

		#endregion

		#region 构造方法

		public CredentialException()
		{
			_message = Resources.ResourceUtility.GetString("Text.CredentialException.Message");
		}

		public CredentialException(string message) : base(message, null)
		{
			_message = string.IsNullOrEmpty(message) ? Resources.ResourceUtility.GetString("Text.CredentialException.Message") : message;
		}

		public CredentialException(string message, Exception innerException) : base(message, innerException)
		{
			_message = string.IsNullOrEmpty(message) ? Resources.ResourceUtility.GetString("Text.CredentialException.Message") : message;
		}

		public CredentialException(string credentialId, string message) : this(credentialId, message, null)
		{
		}

		public CredentialException(string credentialId, string message, Exception innerException) : base(message, innerException)
		{
			_credentialId = credentialId;
			_message = string.IsNullOrEmpty(message) ? Resources.ResourceUtility.GetString("Text.CredentialException.Message") : message;
		}

		protected CredentialException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_credentialId = info.GetString("CredentialId");
		}

		#endregion

		#region 公共属性

		/// <summary>
		/// 获取安全凭证号。
		/// </summary>
		public string CredentialId
		{
			get
			{
				return _credentialId;
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
			info.AddValue("CredentialId", _credentialId);
		}

		#endregion
	}
}