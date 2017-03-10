using System;
using System.Collections.Generic;

namespace JF.Push
{
	/// <summary>
	/// 表示用于描述推送状态的枚举。
	/// </summary>
	[Serializable]
	public enum PushTaskStatus
	{
		/// <summary>
		/// 未知。
		/// </summary>
		Unknow = 1,

		/// <summary>
		/// 准备提交。
		/// </summary>
		Submitting = 2,

		/// <summary>
		/// 推送成功。
		/// </summary>
		Success = 4,

		/// <summary>
		/// 推送失败。
		/// </summary>
		Failure = 8,

		/// <summary>
		/// 已被取消。
		/// </summary>
		Canceled = 16,

		/// <summary>
		/// 已接收。
		/// </summary>
		Received = 32
	}
}
