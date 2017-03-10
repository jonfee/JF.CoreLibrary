using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace JF.Security
{
	/// <summary>
	/// 表示带凭证的用户主体类。
	/// </summary>
	public class CredentialPrincipal : MarshalByRefObject, IPrincipal
	{
		#region 公共字段

		public static readonly CredentialPrincipal Empty = new CredentialPrincipal(CredentialIdentity.Empty);

		#endregion

		#region 成员字段

		private CredentialIdentity _identity;
		private string[] _roles;

		#endregion

		#region 构造方法

		public CredentialPrincipal(CredentialIdentity identity, params string[] roles)
		{
			if(identity == null)
			{
				throw new ArgumentNullException("identity");
			}

			_identity = identity;
			_roles = roles;
		}

		#endregion

		#region 公共属性

		public virtual CredentialIdentity Identity
		{
			get
			{
				return _identity ?? CredentialIdentity.Empty;
			}
		}

		#endregion

		#region 显式实现

		IIdentity IPrincipal.Identity
		{
			get
			{
				return this.Identity;
			}
		}

		bool IPrincipal.IsInRole(string roleName)
		{
			if(string.IsNullOrWhiteSpace(roleName))
			{
				throw new ArgumentNullException("roleName");
			}

			if(_roles == null || _roles.Length < 1)
			{
				return false;
			}

			foreach(var role in _roles)
			{
				if(string.Equals(role, roleName, StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}

			return false;
		}

		#endregion
	}
}