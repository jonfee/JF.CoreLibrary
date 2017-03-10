using System;
using System.Collections.Generic;

namespace JF.Data
{
	/// <summary>
	/// 表示数据分页查询的设置类。
	/// </summary>
	public class Paging
	{
		#region 常量定义

		private const int PAGE_SIZE = 10;

		#endregion

		#region 静态字段

		public static readonly Paging Disable = new Paging(1, 0);

		#endregion

		#region 成员字段

		private int _pageIndex;
		private int _pageSize;
		private long _totalCount;

		#endregion

		#region 构造方法

		/// <summary>
		/// 创建默认的分页设置。<see cref="PageIndex"/>默认值为1（即首页），<see cref="PageSize"/>默认值为20。
		/// </summary>
		public Paging() : this(1, PAGE_SIZE)
		{
		}

		/// <summary>
		/// 创建指定页号的分页设置。<see cref="PageSize"/>默认值为20。
		/// </summary>
		/// <param name="pageIndex"></param>
		public Paging(int pageIndex) : this(pageIndex, PAGE_SIZE)
		{
		}

		/// <summary>
		/// 创建指定页号和页大小的分页设置。
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		public Paging(int pageIndex, int pageSize)
		{
			this.PageIndex = pageIndex;
			this.PageSize = pageSize;
		}

		#endregion

		#region 公共属性

		/// <summary>
		/// 获取或设置页大小，如果该属性值为零则表示不分页。
		/// </summary>
		public int PageSize
		{
			get
			{
				return _pageSize;
			}
			set
			{
				_pageSize = Math.Max(value, 0);
			}
		}

		/// <summary>
		/// 获取或设置当前查询的页号，页号从1开始，如果设置小于1的数值均被重置为1。
		/// </summary>
		public int PageIndex
		{
			get
			{
				return _pageIndex;
			}
			set
			{
				_pageIndex = Math.Max(value, 1);
			}
		}

		/// <summary>
		/// 获取查询结果的总页数。
		/// </summary>
		public int PageCount
		{
			get
			{
				if(_totalCount < 1)
					return 0;

				if(_pageSize < 1)
					return 1;

				return (int)Math.Ceiling((double)_totalCount / _pageSize);
			}
		}

		/// <summary>
		/// 获取或设置查询结果的总记录数。
		/// </summary>
		public long TotalCount
		{
			get
			{
				return _totalCount;
			}
			set
			{
				_totalCount = Math.Max(value, -1);
			}
		}

		#endregion

		#region 静态方法

		/// <summary>
		/// 以指定的页号及大小创建一个分页设置对象。
		/// </summary>
		/// <param name="index">指定的页号，默认为1。</param>
		/// <param name="size">每页的大小，默认为20。</param>
		/// <returns>返回新创建的分页设置对象。</returns>
		public static Paging Page(int index = 1, int size = PAGE_SIZE)
		{
			return new Paging(index, size);
		}

		#endregion
	}
}