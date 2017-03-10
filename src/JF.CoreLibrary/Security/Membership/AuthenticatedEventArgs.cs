using System;
using System.Collections.Generic;

namespace JF.Security.Membership
{
	[Serializable]
	public class AuthenticatedEventArgs : EventArgs
	{
		#region 成员字段

		private bool _isAuthenticated;
		private string _namespace;
		private string _identity;
		private User _user;
		private IDictionary<string, object> _extendedProperties;

		#endregion

		#region 构造方法

		public AuthenticatedEventArgs(string identity, string @namespace, bool isAuthenticated, User user = null)
		{
			_identity = identity;
			_namespace = @namespace;
			_isAuthenticated = isAuthenticated;
			_user = user;
		}

		#endregion

		#region 公共属性

		/// <summary>
		/// 获取身份验证是否通过。
		/// </summary>
		public bool IsAuthenticated
		{
			get
			{
				return _isAuthenticated;
			}
		}

		/// <summary>
		/// 获取身份验证使用的身份标识。
		/// </summary>
		public string Identity
		{
			get
			{
				return _identity;
			}
		}

		/// <summary>
		/// 获取身份验证的命名空间。
		/// </summary>
		public string Namespace
		{
			get
			{
				return _namespace;
			}
		}

		/// <summary>
		/// 获取或设置身份验证对应的用户对象。
		/// </summary>
		public User User
		{
			get
			{
				return _user;
			}
			set
			{
				if(value == null)
				{
					throw new ArgumentNullException();
				}

				_user = value;
			}
		}

		/// <summary>
		/// 获取一个值，指示扩展属性集是否有内容。
		/// </summary>
		public bool HasExtendedProperties
		{
			get
			{
				return _extendedProperties != null && _extendedProperties.Count > 0;
			}
		}

		/// <summary>
		/// 获取验证结果的扩展属性集。
		/// </summary>
		public IDictionary<string, object> ExtendedProperties
		{
			get
			{
				if(_extendedProperties == null)
				{
					System.Threading.Interlocked.CompareExchange(ref _extendedProperties, new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase), null);
				}

				return _extendedProperties;
			}
		}

		#endregion
	}
}