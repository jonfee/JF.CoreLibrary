using System;

namespace JF.Runtime.Caching
{
	/// <summary>
	/// 提供获取适合特定数据大小的缓存管理器。
	/// </summary>
	public interface IBufferManagerSelector
	{
		/// <summary>
		/// 根据指定待缓存的数据大小选取一个合适的<see cref="IBufferManager"/>缓存管理。
		/// </summary>
		/// <param name="size">指定的待缓存的数据大小。</param>
		/// <returns>返回的<see cref="IBufferManager"/>缓存管理器。</returns>
		IBufferManager GetBufferManager(long size);
	}
}