using System;
using System.Collections.Generic;

namespace JF.Text
{
	/// <summary>
	/// 表示表达式节点的集合类。
	/// </summary>
	[Obsolete()]
	public class TextExpressionNodeCollection : JF.Collections.Collection<TextExpressionNode>
	{
		/// <summary>
		/// 表示一个<see cref="TextExpressionNodeCollection"/>类型的空集合。
		/// </summary>
		public static readonly TextExpressionNodeCollection Empty = new TextExpressionNodeCollection();
	}
}