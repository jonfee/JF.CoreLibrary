using System;
using System.ComponentModel;

namespace JF.Security.Membership
{
	/// <summary>
	/// 表示角色成员的类型。
	/// </summary>
	public enum MemberType : byte
	{
		/// <summary>用户成员。</summary>
		[Description("用户")]
		User = 0,

		/// <summary>角色成员。</summary>
		[Description("角色")]
		Role = 1
	}
}