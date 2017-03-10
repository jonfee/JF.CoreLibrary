using System;
using System.Collections.Generic;

namespace JF.Security
{
	/// <summary>
	/// 表示凭证检验器的接口。
	/// </summary>
	public interface ICredentialValidator
	{
		/// <summary>
		/// 校验指定的凭证是否有效。
		/// </summary>
		/// <param name="credential">指定的要检验的<seealso cref="Credential"/>凭证对象。</param>
		/// <returns>如果检验成功则返回真(True)，否则返回假(False)。</returns>
		bool Validate(Credential credential);
	}
}