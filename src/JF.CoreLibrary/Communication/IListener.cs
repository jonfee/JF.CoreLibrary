using System;
using System.Net;

namespace JF.Communication
{
	/// <summary>
	/// 提供关于通讯侦听的功能的接口。
	/// </summary>
	public interface IListener : IDisposable
	{
		/// <summary>
		/// 获取当前是否处于侦听状态。
		/// </summary>
		bool IsListening
		{
			get;
		}

		/// <summary>
		/// 获取通讯侦听器的信息接收处理器对象。
		/// </summary>
		IReceiver Receiver
		{
			get;
		}

		/// <summary>
		/// 开启侦听。
		/// </summary>
		void Start(params string[] args);

		/// <summary>
		/// 停止侦听。
		/// </summary>
		void Stop(params string[] args);
	}
}