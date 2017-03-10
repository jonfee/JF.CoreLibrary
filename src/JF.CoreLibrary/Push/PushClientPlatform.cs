using System;
using System.Collections.Generic;

namespace JF.Push
{
	/// <summary>
	/// 表示推送客户端的操作系统。
	/// </summary>
	[Serializable]
	public enum PushClientPlatform
	{
		/// <summary>
		/// Android
		/// </summary>
		Android = 1,

		/// <summary>
		/// IOS
		/// </summary>
		IOS = 2
	}
}