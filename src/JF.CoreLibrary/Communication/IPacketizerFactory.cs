using System;

namespace JF.Communication
{
	/// <summary>
	/// 提供获取<see cref="IPacketizer"/>通讯协议解析器的接口。
	/// </summary>
	public interface IPacketizerFactory
	{
		/// <summary>
		/// 获取一个<see cref="IPacketizer"/>通讯协议解析器对象。
		/// </summary>
		/// <param name="channel">要获取解析器对应的通道。</param>
		/// <returns>返回获取的解析器，如果获取失败则返回空(null)。</returns>
		IPacketizer GetPacketizer(IChannel channel);
	}
}