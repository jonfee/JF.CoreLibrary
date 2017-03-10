using System;
using System.Collections.Generic;

namespace JF.Push
{
	/// <summary>
	/// 表示一条数据透传消息。
	/// 仅当客户端在线时，数据经SDK传给客户端，由客户端决定如何处理展现给用户。
	/// </summary>
	[Serializable]
	public class TransmissionMessage : PushMessage
	{
		#region 构造方法

		/// <summary>
		/// 初始化 <see cref="TransmissionMessage"/> 类的新实例。
		/// </summary>
		public TransmissionMessage() : base(PushMessageType.Transmission)
		{

		}

		#endregion
	}
}
