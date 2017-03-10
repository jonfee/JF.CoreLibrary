using System;
using System.Collections.Generic;

namespace JF.Security.Membership
{
	[Serializable]
	public class AuthorizationEventArgs : EventArgs
	{
		#region 成员字段

		private CredentialPrincipal _principal;
		private long _userId;
		private string _schemaId;
		private string _actionId;
		private bool _isAuthorized;

		#endregion

		#region 构造方法

		public AuthorizationEventArgs(long userId, string schemaId, string actionId, bool isAuthorized)
		{
			_userId = userId;
			_schemaId = schemaId;
			_actionId = actionId;
			_isAuthorized = isAuthorized;
		}

		public AuthorizationEventArgs(CredentialPrincipal principal, string schemaId, string actionId, bool isAuthorized)
		{
			if(principal == null)
			{
				throw new ArgumentNullException("principal");
			}

			_principal = principal;
			_schemaId = schemaId;
			_actionId = actionId;
			_isAuthorized = isAuthorized;
		}

		#endregion

		#region 公共属性

		/// <summary>
		/// 获取待授权的<seealso cref="CredentialPrincipal"/>凭证主体。
		/// </summary>
		public CredentialPrincipal Principal
		{
			get
			{
				return _principal;
			}
		}

		/// <summary>
		/// 获取待授权的用户编号。
		/// </summary>
		public long UserId
		{
			get
			{
				if(_principal != null && _principal.Identity != null && _principal.Identity.Credential != null)
				{
					return _principal.Identity.Credential.UserId;
				}

				return _userId;
			}
		}

		/// <summary>
		/// 获取待授权的资源标识。
		/// </summary>
		public string SchemaId
		{
			get
			{
				return _schemaId;
			}
		}

		/// <summary>
		/// 获取待授权的行为标识。
		/// </summary>
		public string ActionId
		{
			get
			{
				return _actionId;
			}
		}

		/// <summary>
		/// 获取或设置是否授权通过。
		/// </summary>
		public bool IsAuthorized
		{
			get
			{
				return _isAuthorized;
			}
			set
			{
				_isAuthorized = value;
			}
		}

		#endregion
	}
}