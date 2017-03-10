using System;
using System.IO;
using System.Collections.Generic;

namespace JF.Communication
{
	/// <summary>
	/// 提供通讯协议解析功能的接口。
	/// </summary>
	public interface IPacketizer
	{
		/// <summary>
		/// 将指定的源数据字节组信息解析(打包)成待发送的字节组信息集。
		/// </summary>
		/// <param name="buffer">要发送的待解析(打包)的源数据字节组信息。</param>
		/// <returns>返回解析(打包)成功后的字节组信息集。</returns>
		/// <remarks>
		///		<para>注意：实现者应确保该方法的返回结果始终不能为空(null)。</para>
		/// </remarks>
		IEnumerable<JF.Common.Buffer> Pack(JF.Common.Buffer buffer);

		/// <summary>
		/// 将指定的源数据流解析(打包)成待发送的字节组信息集。
		/// </summary>
		/// <param name="stream">要发送的待解析(打包)的源数据流。</param>
		/// <returns>返回解析(打包)成功后的字节组信息集。</returns>
		/// <remarks>
		///		<para>注意：实现者应确保该方法的返回结果始终不能为空(null)。</para>
		/// </remarks>
		IEnumerable<JF.Common.Buffer> Pack(Stream stream);

		/// <summary>
		/// 将接收到的字节组信息解析(解包)成目标数据集。
		/// </summary>
		/// <param name="buffer">接收到的待解析(解包)的字节组信息。</param>
		/// <returns>返回解析(解包)成功后的目标数据集。</returns>
		/// <remarks>
		///		<para>注意：实现者应确保该方法的返回结果始终不能为空(null)。</para>
		/// </remarks>
		IEnumerable<object> Unpack(JF.Common.Buffer buffer);
	}
}