using System;
using System.Collections.Generic;

namespace JF.Data
{
	/// <summary>
	/// 表示数据排序的设置项。
	/// </summary>
	public class Sorting : ISorting
	{
		#region 公共属性
		
		public string Name
		{
			get;
			protected set;
		}
		
		public SortingMode Mode
		{
			get;
			protected set;
		}

		#endregion

		#region 构造方法

		/// <summary>
		/// 初始化 <see cref="Sorting"/> 类的新实例。
		/// </summary>
		protected Sorting()
		{

		}

		/// <summary>
		/// 初始化 <see cref="Sorting"/> 类的新实例。
		/// </summary>
		/// <param name="name">成员名称。</param>
		/// <param name="mode">排序方式。</param>
		public Sorting(string name, SortingMode mode)
		{
			if(string.IsNullOrWhiteSpace(name))
				throw new ArgumentNullException(nameof(name));

			this.Name = name;
			this.Mode = mode;
		}

		#endregion
	}

	/// <summary>
	/// 表示数据排序的方式。
	/// </summary>
	public enum SortingMode
	{
		/// <summary>正序</summary>
		Ascending,

		/// <summary>倒序</summary>
		Descending,
	}
}