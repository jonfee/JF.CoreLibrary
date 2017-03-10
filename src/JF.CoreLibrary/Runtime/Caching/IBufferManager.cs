using System;
using System.IO;

namespace JF.Runtime.Caching
{
	/// <summary>
	/// 提供缓存管理的功能。
	/// </summary>
	public interface IBufferManager
	{
		/// <summary>
		/// 分配指定大小的缓存空间。
		/// </summary>
		/// <param name="size">指定要分配的缓存大小，单位为字节。</param>
		/// <returns>返回分配成功的缓存号，负数表示分配失败。</returns>
		int Allocate(long size);

		/// <summary>
		/// 释放指定缓存号的缓存空间。
		/// </summary>
		/// <param name="id">指定要释放的缓存号。</param>
		void Release(int id);

		/// <summary>
		/// 获取指定缓存号对应的<seealso cref="System.IO.Stream"/>缓存流。
		/// </summary>
		/// <param name="id">指定要获取的缓存号。</param>
		/// <returns>返回的对应<paramref name="id"/>参数值的缓存流。</returns>
		Stream GetStream(int id);

		#region 读取方法

		/// <summary>
		/// 将指定缓存号对应的缓存内容读取到指定的<seealso cref="System.IO.Stream"/>流中。
		/// </summary>
		/// <param name="id">指定的要读取的缓存号。</param>
		/// <param name="stream">指定的要读取缓存内容到的目标流。</param>
		/// <param name="count">指定的要读取的字节数。</param>
		/// <returns>返回实际读取成功的字节数。</returns>
		int Read(int id, Stream stream, int count);

		/// <summary>
		/// 将指定缓存号对应的缓存内容读取到指定的<seealso cref="System.IO.Stream"/>流中。
		/// </summary>
		/// <param name="id">指定的要读取的缓存号。</param>
		/// <param name="position">指定的缓存区的读取起始位置。</param>
		/// <param name="stream">指定的要读取缓存内容到的目标流。</param>
		/// <param name="count">指定的要读取的字节数。</param>
		/// <returns>返回实际读取成功的字节数。</returns>
		/// <remarks>
		///		<para>对实现者：本次读取操作不应该影响指定缓存号对应缓存流的内部Position位置值。</para>
		/// </remarks>
		int Read(int id, long position, Stream stream, int count);

		/// <summary>
		/// 将指定缓存号对应的缓存内容读取到指定的字节数组中。
		/// </summary>
		/// <param name="id">指定的要读取的缓存号。</param>
		/// <param name="buffer">指定的要读取缓存内容到的目标字节数组。</param>
		/// <param name="offset">指定的从目标字节数组的写入起始位置。</param>
		/// <param name="count">指定的要读取的字节数。</param>
		/// <returns>返回实际读取成功的字节数。</returns>
		int Read(int id, byte[] buffer, int offset, int count);

		/// <summary>
		/// 将指定缓存号对应的缓存内容读取到指定的字节数组中。
		/// </summary>
		/// <param name="id">指定的要读取的缓存号。</param>
		/// <param name="position">指定的缓存区的读取起始位置。</param>
		/// <param name="buffer">指定的要读取缓存内容到的目标字节数组。</param>
		/// <param name="offset">指定的从目标字节数组的写入起始位置。</param>
		/// <param name="count">指定的要读取的字节数。</param>
		/// <returns>返回实际读取成功的字节数。</returns>
		/// <remarks>
		///		<para>对实现者：本次读取操作不应该影响指定缓存号对应缓存流的内部Position位置值。</para>
		/// </remarks>
		int Read(int id, long position, byte[] buffer, int offset, int count);

		#endregion

		#region 写入方法

		/// <summary>
		/// 将指定<seealso cref="System.IO.Stream"/>流的数据写入到指定缓存号对应的缓存区中。
		/// </summary>
		/// <param name="id">指定的要写入的缓存号。</param>
		/// <param name="stream">指定的要写入到缓存区的数据流。</param>
		/// <param name="count">指定的要写入的字节数。</param>
		/// <returns>返回实际写入成功的字节数。</returns>
		void Write(int id, Stream stream, int count);

		/// <summary>
		/// 将指定<seealso cref="System.IO.Stream"/>流的数据写入到指定缓存号对应的缓存区中。
		/// </summary>
		/// <param name="id">指定的要写入的缓存号。</param>
		/// <param name="position">指定的缓存区的写入起始位置。</param>
		/// <param name="stream">指定的要写入到缓存区的数据流。</param>
		/// <param name="count">指定的要写入的字节数。</param>
		/// <returns>返回实际写入成功的字节数。</returns>
		void Write(int id, long position, Stream stream, int count);

		/// <summary>
		/// 将指定<seealso cref="System.IO.Stream"/>流的数据写入到指定缓存号对应的缓存区中。
		/// </summary>
		/// <param name="id">指定的要写入的缓存号。</param>
		/// <param name="buffer">指定的要写入到缓存区的字节数组。</param>
		/// <param name="offset">指定的从源字节数组的读取起始位置。</param>
		/// <param name="count">指定的要写入的字节数。</param>
		void Write(int id, byte[] buffer, int offset, int count);

		/// <summary>
		/// 将指定<seealso cref="System.IO.Stream"/>流的数据写入到指定缓存号对应的缓存区中。
		/// </summary>
		/// <param name="id">指定的要写入的缓存号。</param>
		/// <param name="position">指定的缓存区的写入起始位置。</param>
		/// <param name="buffer">指定的要写入到缓存区的字节数组。</param>
		/// <param name="offset">指定的从源字节数组的读取起始位置。</param>
		/// <param name="count">指定的要写入的字节数。</param>
		void Write(int id, long position, byte[] buffer, int offset, int count);

		#endregion
	}
}