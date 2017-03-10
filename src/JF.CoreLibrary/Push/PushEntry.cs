using System;
using System.Collections.Generic;

namespace JF.Push
{
	/// <summary>
	/// 表示推送项的描述。
	/// </summary>
	[Serializable]
	public class PushEntry
	{
		#region 成员字段

		private PushClient _client;
		private PushMessage _message;

		#endregion

		#region 公共属性

		/// <summary>
		/// 获取或设置客户端。
		/// </summary>
		public PushClient Client
		{
			get
			{
				return _client;
			}
			set
			{
				if(value == null)
					throw new ArgumentNullException();

				this._client = value;
			}
		}

		/// <summary>
		/// 获取或设置消息。
		/// </summary>
		public PushMessage Message
		{
			get
			{
				return _message;
			}
			set
			{
				if(value == null)
					throw new ArgumentNullException();

				this._message = value;
			}
		}

		#endregion

		#region 构造方法

		/// <summary>
		/// 初始化 <see cref="PushEntry"/> 类的新实例。
		/// </summary>
		/// <param name="client">待推送的客户端。</param>
		/// <param name="message">待推送的消息实例。</param>
		public PushEntry(PushClient client, PushMessage message)
		{
			this.Client = client;
			this.Message = message;
		}

		#endregion
	}
}
