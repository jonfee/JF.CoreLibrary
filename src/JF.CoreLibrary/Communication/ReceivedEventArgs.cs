using System;
using System.IO;

namespace JF.Communication
{
	[Serializable]
	public class ReceivedEventArgs : ChannelEventArgs
	{
		#region 成员字段

		private object _receivedObject;

		#endregion

		#region 构造方法

		public ReceivedEventArgs(IChannel channel, object receivedObject) : base(channel)
		{
			if(receivedObject == null)
			{
				throw new ArgumentNullException("receivedObject");
			}

			_receivedObject = receivedObject;
		}

		#endregion

		#region 公共属性

		/// <summary>
		/// 获取接受到的对象。
		/// </summary>
		public object ReceivedObject
		{
			get
			{
				return _receivedObject;
			}
		}

		#endregion
	}
}