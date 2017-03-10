using System;
using System.Collections.Generic;

namespace JF.Security
{
	/// <summary>
	/// 表示单词或词语的审查。
	/// </summary>
	public interface ICensorship
	{
		/// <summary>
		/// 判断指定的<paramref name="word"/>词汇是否为非法的。
		/// </summary>
		/// <param name="word">指定要判断的单词或词语。</param>
		/// <param name="keys">指定要判断的单词或词语所属的审查类别。</param>
		/// <returns>如果指定的单词或词语是非法的(敏感词)则返回真(True)，否则返回假(False)。</returns>
		bool IsBlocked(string word, params string[] keys);
	}
}