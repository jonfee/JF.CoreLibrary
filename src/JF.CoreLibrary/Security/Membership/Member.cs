using System;
using System.Collections.Generic;

namespace JF.Security.Membership
{
	/// <summary>
	/// 表示角色成员的实体类。
	/// </summary>
	[Serializable]
	public class Member
	{
		#region 成员字段

		private long _roleId;
		private Role _role;
		private long _memberId;
		private MemberType _memberType;
		private object _memberObject;

		#endregion

		#region 构造方法

		public Member(long roleId, long memberId, MemberType memberType)
		{
			_roleId = roleId;
			_memberId = memberId;
			_memberType = memberType;
		}

		#endregion

		#region 公共属性

		/// <summary>
		/// 获取或设置成员的父角色编号。
		/// </summary>
		public long RoleId
		{
			get
			{
				return _roleId;
			}
			set
			{
				_roleId = value;
			}
		}

		/// <summary>
		/// 获取或设置成员的父角色对象。
		/// </summary>
		public Role Role
		{
			get
			{
				return _role;
			}
			set
			{
				_role = value;
			}
		}

		/// <summary>
		/// 获取或设置成员编号。
		/// </summary>
		public long MemberId
		{
			get
			{
				return _memberId;
			}
			set
			{
				_memberId = value;
			}
		}

		/// <summary>
		/// 获取或设置成员类型。
		/// </summary>
		public MemberType MemberType
		{
			get
			{
				return _memberType;
			}
			set
			{
				_memberType = value;
			}
		}

		/// <summary>
		/// 获取或设置成员自身对象，具体类型由<see cref="MemberType"/>属性标示。
		/// </summary>
		/// <exception cref="ArgumentException">当设置的值不为空，并且不是<seealso cref="User"/>用户或<seealso cref="Role"/>角色类型。</exception>
		public object MemberObject
		{
			get
			{
				return _memberObject;
			}
			set
			{
				if(value == null || value is User || value is Role)
				{
					_memberObject = value;
				}
				else
				{
					throw new ArgumentException("The type of value must be 'User' or 'Role'.");
				}
			}
		}

		#endregion

		#region 重写方法

		public override bool Equals(object obj)
		{
			if(obj == null || obj.GetType() != this.GetType())
			{
				return false;
			}

			var other = (Member)obj;

			return _roleId == other._roleId && _memberId == other._memberId && _memberType == other._memberType;
		}

		public override int GetHashCode()
		{
			return (_roleId + ":" + _memberId + "[" + _memberType.ToString() + "]").ToLowerInvariant().GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("{0}:{1}({2})", _roleId, _memberId, _memberType);
		}

		#endregion
	}
}