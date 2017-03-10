using System;
using System.ComponentModel;

namespace JF.Security.Membership
{
	/// <summary>
	/// 表示验证失败原因的枚举。
	/// </summary>
	public enum AuthenticationReason
	{
		/// <summary>验证成功</summary>
		[Description("${Text.AuthenticationReason.Succeed}")]
		Succeed = 0,

		/// <summary>未知的原因</summary>
		[Description("${Text.AuthenticationReason.Unknown}")]
		Unknown = -1,

		/// <summary>无效的身份标识</summary>
		[Description("${Text.AuthenticationReason.InvalidIdentity}")]
		InvalidIdentity = 1,

		/// <summary>无效的密码</summary>
		[Description("${Text.AuthenticationReason.InvalidPassword}")]
		InvalidPassword = 2,

		/// <summary>帐户尚未批准</summary>
		[Description("${Text.AuthenticationReason.AccountUnapproved}")]
		AccountUnapproved = 3,

		/// <summary>帐户被暂时挂起（可能是因为密码验证失败次数过多。）</summary>
		[Description("${Text.AuthenticationReason.AccountSuspended}")]
		AccountSuspended = 4,

		/// <summary>帐户已被禁用</summary>
		[Description("${Text.AuthenticationReason.AccountDisabled}")]
		AccountDisabled = 5,
	}
}