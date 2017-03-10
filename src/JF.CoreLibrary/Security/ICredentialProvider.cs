using System;
using System.Collections.Generic;

namespace JF.Security
{
	/// <summary>
	/// 提供安全凭证相关操作的功能。
	/// </summary>
	public interface ICredentialProvider
	{
		/// <summary>
		/// 为指定的用户注册安全凭证。
		/// </summary>
		/// <param name="user">指定的用户对象。</param>
		/// <param name="scene">指定的应用场景，通常为“Web”、“Mobile”等。</param>
		/// <param name="extendedProperties">扩展属性集合。</param>
		Credential Register(Membership.User user, string scene, IDictionary<string, object> extendedProperties = null);

		/// <summary>
		/// 从安全凭证容器中注销指定的凭证。
		/// </summary>
		/// <param name="credentialId">指定的要注销的安全凭证编号。</param>
		void Unregister(string credentialId);

		/// <summary>
		/// 续约指定的安全凭证。
		/// </summary>
		/// <param name="credentialId">指定要续约的安全凭证编号。</param>
		Credential Renew(string credentialId);

		/// <summary>
		/// 获取当前安全凭证容器内的所有凭证数。
		/// </summary>
		/// <returns>返回的安全凭证数量。</returns>
		/// <remarks>
		///		<para>返回的凭证数包括有效和过期无效的凭证。</para>
		/// </remarks>
		int GetCount();

		/// <summary>
		/// 获取当前安全凭证容器内的指定命名空间下的凭证数。
		/// </summary>
		/// <param name="namespace">指定的命名空间。</param>
		/// <returns>返回的安全凭证数量。</returns>
		/// <remarks>
		///		<para>返回的凭证数包括有效和过期无效的凭证。</para>
		/// </remarks>
		int GetCount(string @namespace);

		/// <summary>
		/// 验证指定的安全凭证号是否有效。
		/// </summary>
		/// <param name="credentialId">指定的要验证的安全凭证号。</param>
		/// <returns>如果验证成功则返回真(True)，否则返回假(False)。</returns>
		bool Validate(string credentialId);

		/// <summary>
		/// 获取指定安全凭证号对应的应用编号。
		/// </summary>
		/// <param name="credentialId">指定的安全凭证号。</param>
		/// <returns>返回对应的应用编号，如果为空(null)则表示该凭证号无效。</returns>
		string GetNamespace(string credentialId);

		/// <summary>
		/// 获取指定安全凭证编号对应的<see cref="Credential"/>安全凭证对象。
		/// </summary>
		/// <param name="credentialId">指定要获取的安全凭证编号。</param>
		/// <returns>返回的对应的安全凭证对象，如果指定的安全凭证编号不存在则返回空(null)。</returns>
		Credential GetCredential(string credentialId);

		/// <summary>
		/// 获取指定用户及应用场景对应的<see cref="Credential"/>安全凭证对象。
		/// </summary>
		/// <param name="userId">指定要获取的安全凭证对应的用户编号。</param>
		/// <param name="scene">指定要获取的安全凭证对应的应用场景。</param>
		/// <returns>返回成功的安全凭证对象，如果指定的用户及应用场景不存在对应的安全凭证则返回空(null)。</returns>
		Credential GetCredential(long userId, string scene);

		/// <summary>
		/// 获取指定命名空间中的所有<see cref="Credential"/>安全凭证对象集。
		/// </summary>
		/// <param name="namespace">指定要获取的安全凭证所属的命名空间。</param>
		/// <returns>返回的对应的安全凭证对象集，如果指定的应用下无安全凭证则返回空集合。</returns>
		IEnumerable<Credential> GetCredentials(string @namespace);
	}
}