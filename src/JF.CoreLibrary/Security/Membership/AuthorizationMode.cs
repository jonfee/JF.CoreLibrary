using System;
using System.ComponentModel;

namespace JF.Security.Membership
{
	/// <summary>
	/// 表示在授权验证模块中对当前用户的操作行为进行授权处理的方式。
	/// </summary>
	public enum AuthorizationMode
	{
		/// <summary>禁止授权验证，即对当前处理不做授权验证。</summary>
		Disabled,

		/// <summary>仅限身份验证，即当前调用为非匿名调用即通过。</summary>
		Identity,

		/// <summary>必须授权验证通过。</summary>
		Required,
	}
}