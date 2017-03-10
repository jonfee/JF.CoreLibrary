using System;

namespace JF.IO
{
	/// <summary>
	/// 表示关于路径的锚定点。
	/// </summary>
	public enum PathAnchor
	{
		/// <summary>未锚定</summary>
		None,

		/// <summary>基于当前位置</summary>
		Current,

		/// <summary>基于上级节点</summary>
		Parent,

		/// <summary>从根节点开始</summary>
		Root,
	}
}