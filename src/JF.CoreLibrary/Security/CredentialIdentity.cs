﻿using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace JF.Security
{
	/// <summary>
	/// 表示带凭证的用户标识类。
	/// </summary>
	public class CredentialIdentity : MarshalByRefObject, IIdentity
	{
		#region 公共字段

		public static readonly CredentialIdentity Empty = new CredentialIdentity();

		#endregion

		#region 成员字段

		private string _credentialId;
		private Credential _credential;
		private ICredentialProvider _provider;

		#endregion

		#region 构造方法

		private CredentialIdentity()
		{
			_credentialId = string.Empty;
		}

		public CredentialIdentity(string credentialId, ICredentialProvider provider = null)
		{
			if(string.IsNullOrWhiteSpace(credentialId))
			{
				throw new ArgumentNullException("credentialId");
			}

			_credentialId = credentialId;
			_provider = provider;
		}

		#endregion

		#region 公共属性

		public string Name
		{
			get
			{
				var credential = this.Credential;

				if(credential == null || credential.User == null)
				{
					return string.Empty;
				}

				return credential.User.Name;
			}
		}

		public bool IsAuthenticated
		{
			get
			{
				if(string.IsNullOrWhiteSpace(_credentialId))
				{
					return false;
				}

				//获取当前凭证对象
				var credential = this.Credential;

				//只有当凭证对象不为空并且对应的用户对象也不为空才算验证通过
				return credential != null && credential.User != null;
			}
		}

		public string CredentialId
		{
			get
			{
				return _credentialId;
			}
		}

		public virtual Credential Credential
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
			get
			{
				if(string.IsNullOrWhiteSpace(_credentialId))
				{
					return null;
				}

				if(_credential == null)
				{
					var provider = this.Provider;

					if(provider != null)
					{
						_credential = provider.GetCredential(_credentialId);
					}
				}

				return _credential;
			}
		}

		public ICredentialProvider Provider
		{
			get
			{
				return _provider;
			}
			set
			{
				if(value == null)
				{
					throw new ArgumentNullException();
				}

				_provider = value;
			}
		}

		#endregion

		#region 显式实现

		string IIdentity.AuthenticationType
		{
			get
			{
				return "Newlife Credentials Authentication";
			}
		}

		#endregion
	}
}