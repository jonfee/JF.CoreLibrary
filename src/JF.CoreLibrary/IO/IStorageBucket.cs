using System;
using System.Collections.Generic;

namespace JF.IO
{
	/// <summary>
	/// 表示<see cref="IStorageBucket">存储文件容器</see>的操作接口。
	/// </summary>
	[Obsolete("Please use Aliyun-OSS providr of filesystem.")]
	public interface IStorageBucket
	{
		/// <summary>
		/// 创建一个<see cref="IStorageBucket"/>存储文件容器。
		/// </summary>
		/// <param name="bucketId">文件存储容器的唯一编号。</param>
		/// <param name="name">文件存储容器的名称。</param>
		/// <param name="title">文件存储容器的标题。</param>
		/// <param name="path">文件存储容器的路径。</param>
		/// <returns>返回创建成功的<see cref="IStorageBucket"/>容器描述类。</returns>
		StorageBucketInfo Create(int bucketId, string name, string title, string path);

		/// <summary>
		/// 获取指定编号的文件存储容器。
		/// </summary>
		/// <param name="bucketId">指定要查找的文件存储容器编号。</param>
		/// <returns>返回指定编号的存储容器，如果指定编号的文件存储容器不存在则返回空(null)。</returns>
		StorageBucketInfo GetInfo(int bucketId);

		/// <summary>
		/// 获取指定编号的文件存储容器的路径。
		/// </summary>
		/// <param name="bucketId">指定要查找的文件容器编号</param>
		/// <returns>返回的文件存储容器路径，如果指定编号的文件容器不存在则返回空(null)。</returns>
		string GetPath(int bucketId);

		/// <summary>
		/// 删除指定编号的文件存储容器。
		/// </summary>
		/// <param name="bucketId">指定要删除的文件存储容器编号。</param>
		/// <returns>如果删除成功则返回真(True)，否则返回假(False)。</returns>
		bool Delete(int bucketId);

		/// <summary>
		/// 修改指定编号的文件存储容器的信息。
		/// </summary>
		/// <param name="bucketId">指定要修改的文件存储容器编号。</param>
		/// <param name="name">要修改的文件存储容器的名称，如果为空(null)则不修改。</param>
		/// <param name="title">要修改的文件存储容器的标题，如果为空(null)则不修改。</param>
		/// <param name="path">要修改的文件存储容器的路径，如果为空(null)则不修改。</param>
		/// <param name="modifiedTime">要修改的文件存储容器的最后修改时间。</param>
		void Modify(int bucketId, string name, string title, string path, DateTime? modifiedTime);

		/// <summary>
		/// 获取系统中的文件存储容器的总数。
		/// </summary>
		/// <returns>返回的文件存储容器总数。</returns>
		int GetBucketCount();

		/// <summary>
		/// 获取指定文件存储容器中的文件总数。
		/// </summary>
		/// <param name="bucketId">指定要获取的文件存储容器编号。</param>
		/// <returns>返回的文件总数。</returns>
		int GetFileCount(int bucketId);
	}
}