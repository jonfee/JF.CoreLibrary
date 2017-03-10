using System;
using System.Collections.Generic;

namespace JF.Push
{
	/// <summary>
	/// 用于表述客户端状态的枚举。
	/// </summary>
	[Serializable]
	public enum PushClientStatus
	{
		/// <summary>
		/// 离线。
		/// </summary>
		Offline = 0,

		/// <summary>
		/// 在线。
		/// </summary>
		Online = 1
	}
}
