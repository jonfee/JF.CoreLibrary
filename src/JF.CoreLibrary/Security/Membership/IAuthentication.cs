using System;

namespace JF.Security.Membership
{
	/// <summary>
	/// 提供关于用户安全验证的接口。
	/// </summary>
	public interface IAuthentication
	{
		/// <summary>
		/// 表示验证完成的事件。
		/// </summary>
		event EventHandler<AuthenticatedEventArgs> Authenticated;

		/// <summary>
		/// 验证指定名称的用户是否有效并且和指定的密码是否完全匹配。
		/// </summary>
		/// <param name="identity">要验证的用户标识，可以是“用户名”、“手机号码”或者“邮箱地址”。</param>
		/// <param name="password">指定用户的密码。</param>
		/// <param name="namespace">要验证的用户标识所属的命名空间。</param>
		/// <returns>如果验证成功则返回一个有效的<see cref="AuthenticationResult"/>对象。验证失败会抛出<seealso cref="JF.Security.Membership.AuthenticationException"/>异常。</returns>
		/// <exception cref="JF.Security.Membership.AuthenticationException">当验证失败。</exception>
		AuthenticationResult Authenticate(string identity, string password, string @namespace = null);
	}
}