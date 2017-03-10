using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using JF.Common;
using JF.ComponentModel;

namespace JF.Push
{
	/// <summary>
	/// 表示推送消息的基类。
	/// </summary>
	[Serializable]
	public abstract class PushMessage
	{
		#region 成员字段

		private PushMessageType _type;
		private DateTime? _appointmentTime;
		private Dictionary<string, object> _payload = new Dictionary<string, object>();

		#endregion

		#region 公共属性

		/// <summary>
		/// 获取或设置预约发送时间，如果该值为空，则当前消息将及时发送。
		/// </summary>
		public DateTime? AppointmentTime
		{
			get
			{
				return _appointmentTime;
			}
			set
			{
				_appointmentTime = value;
			}
		}

		/// <summary>
		/// 获取当前消息的类型。
		/// </summary>
		public PushMessageType Type
		{
			get
			{
				return _type;
			}
		}

		/// <summary>
		/// 获取或设置消息承载的数据，可根据业务逻辑自定义数据。
		/// </summary>
		public Dictionary<string, object> Payload
		{
			get
			{
				return _payload;
			}
			set
			{
				_payload = value;
			}
		}

		#endregion

		#region 构造方法

		/// <summary>
		/// 初始化 <see cref="PushMessage"/> 类的新实例。
		/// </summary>
		/// <param name="type">消息类型。</param>
		protected PushMessage(PushMessageType type)
		{
			// 设置消息类型。
			this._type = type;
		}

		#endregion
	}
}
