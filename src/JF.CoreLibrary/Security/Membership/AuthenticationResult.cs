using System;
using System.Collections.Generic;

namespace JF.Security.Membership
{
	/// <summary>
	/// 表示验证通过的结果。
	/// </summary>
	[Serializable]
	public class AuthenticationResult
	{
		#region 成员字段

		private User _user;
		private IDictionary<string, object> _extendedProperties;

		#endregion

		#region 构造方法

		public AuthenticationResult(User user) : this(user, null)
		{
		}

		public AuthenticationResult(User user, IDictionary<string, object> extendedProperties)
		{
			if(user == null)
			{
				throw new ArgumentNullException("user");
			}

			_user = user;

			if(extendedProperties != null && extendedProperties.Count > 0)
			{
				_extendedProperties = new Dictionary<string, object>(extendedProperties, StringComparer.OrdinalIgnoreCase);
			}
		}

		#endregion

		#region 公共属性

		/// <summary>
		/// 获取验证通过后的用户对象，如果验证失败则返回空(null)。
		/// </summary>
		public User User
		{
			get
			{
				return _user;
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