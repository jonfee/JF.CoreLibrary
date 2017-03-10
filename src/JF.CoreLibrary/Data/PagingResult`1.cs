using System;
using System.Collections.Generic;

namespace JF.Data
{
	/// <summary>
	/// 表示分页查询后的结果。
	/// </summary>
	/// <typeparam name="T">数据类型。</typeparam>
	public class PagingResult<T>
	{
		#region 静态字段

		/// <summary>
		/// 获取一个空的分页结果。
		/// </summary>
		public static readonly PagingResult<T> Empty = new PagingResult<T>(0, 0, new List<T>());

		#endregion

		#region 公共属性

		/// <summary>
		/// 获取或设置总记录数。
		/// </summary>
		public int RecordCount
		{
			get;
			set;
		}

		/// <summary>
		/// 获取或设置总页数。
		/// </summary>
		public int PageCount
		{
			get;
			set;
		}

		/// <summary>
		/// 获取或设置当前页数据。
		/// </summary>
		public IEnumerable<T> Records
		{
			get;
			set;
		}

		#endregion

		#region 构造方法

		/// <summary>
		/// 初始化一个新的 <see cref="PagingResult"/> 类型的实例。
		/// </summary>
		public PagingResult()
		{
			this.Records = new List<T>();
		}

		/// <summary>
		/// 初始化一个新的 <see cref="PagingResult"/> 类型的实例。
		/// </summary>
		/// <param name="recordCount">总记录数。</param>
		/// <param name="pageCount">总页数。</param>
		/// <param name="records">当前页面的数据。</param>
		public PagingResult(int recordCount, int pageCount, IEnumerable<T> records)
		{
			this.PageCount = recordCount;
			this.PageCount = pageCount;
			this.Records = records;
		}

		#endregion
	}
}
