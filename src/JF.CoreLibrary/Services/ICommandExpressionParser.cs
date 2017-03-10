using System;

namespace JF.Services
{
	/// <summary>
	/// 提供命令行文本解析功能。
	/// </summary>
	public interface ICommandExpressionParser
	{
		/// <summary>
		/// 将指定的命令行文本解析成命令表达式对象。
		/// </summary>
		/// <param name="text">指定的要解析的命令行文本。</param>
		/// <returns>返回解析的命令表达式对象，如果解析失败则返回空(null)。</returns>
		/// <exception cref="CommandExpressionException">无效的命令行文本。</exception>
		CommandExpression Parse(string text);
	}
}