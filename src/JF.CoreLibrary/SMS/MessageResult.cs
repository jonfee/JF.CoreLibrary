using System;
using System.Collections.Generic;

namespace JF.SMS
{
	/// <summary>
	/// 表示针对单条消息的结果。
	/// </summary>
	[Serializable]
	public class MessageResult
	{
		#region 成员字段

		private bool _success;
		private string _description;
		private string _mobile;
		private string _taskId;

		#endregion

		#region 成员属性

		/// <summary>
		/// 获取或设置本次发送是否成功。
		/// </summary>
		public bool Success
		{
			get
			{
				return _success;
			}
			set
			{
				_success = value;
			}
		}

		/// <summary>
		/// 获取或设置本次发送的短信任务ID。(短信服务商提供，只有发送成功才会返回。)
		/// </summary>
		public string TaskId
		{
			get
			{
				return _taskId;
			}
			set
			{
				_taskId = value;
			}
		}

		/// <summary>
		/// 获取或设置本次发送的手机号。
		/// </summary>
		public string Mobile
		{
			get
			{
				return _mobile;
			}
			set
			{
				if(string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException();

				_mobile = value;
			}
		}

		/// <summary>
		/// 获取或设置本次发送的响应信息。
		/// (例如"发送成功"，或发送失败时的错误信息。)
		/// </summary>
		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				_description = value;
			}
		}

		#endregion
	}
}
