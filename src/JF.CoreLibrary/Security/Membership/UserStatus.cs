using System;
using System.ComponentModel;

namespace JF.Security.Membership
{
	/// <summary>
	/// 表示用户状态的枚举。
	/// </summary>
	public enum UserStatus : byte
	{
		/// <summary>正常可用</summary>
		Active = 0,

		/// <summary>待审核</summary>
		Unapproved,

		/// <summary>已停用</summary>
		Disabled,

		/// <summary>被挂起，特指密码验证失败超过特定次数。</summary>
		Suspended,
	}
}