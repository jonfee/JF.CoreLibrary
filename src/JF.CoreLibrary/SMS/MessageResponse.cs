using System;
using System.Linq;
using System.Collections.Generic;

using JF.Resources;

namespace JF.SMS
{
	/// <summary>
	/// 表示消息发送响应结果。
	/// </summary>
	[Serializable]
	public class MessageResponse
	{
		#region 公共属性

		/// <summary>
		/// 获取或设置提交响应状态。
		/// </summary>
		public bool Status
		{
			get;
			set;
		}

		/// <summary>
		/// 获取或设置提交响应描述。
		/// </summary>
		public string Description
		{
			get;
			set;
		}

		/// <summary>
		/// 获取或设置本次提交的所有响应结果。
		/// </summary>
		public IEnumerable<MessageResult> Results
		{
			get;
			set;
		}

		#endregion
	}
}
