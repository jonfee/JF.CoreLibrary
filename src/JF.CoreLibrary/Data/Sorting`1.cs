using System;
using System.Collections.Generic;

using JF.Common;

namespace JF.Data
{
	/// <summary>
	/// 表示数据排序的设置项。
	/// </summary>
	/// <typeparam name="T">枚举类型。</typeparam>
	public class Sorting<T> : Sorting where T : struct
	{
		#region 公共属性

		/// <summary>
		/// 获取排序成员。
		/// </summary>
		public T Member
		{
			get;
			private set;
		}

		#endregion

		#region 构造方法

		/// <summary>
		/// 初始化 <see cref="Sorting"/> 类的新实例。
		/// </summary>
		/// <param name="member">排序成员。</param>
		public Sorting(T member) : this(member, SortingMode.Descending)
		{

		}

		/// <summary>
		/// 初始化 <see cref="Sorting"/> 类的新实例。 
		/// </summary>
		/// <param name="member">排序成员。</param>
		/// <param name="mode">排序方式。</param>
		public Sorting(T member, SortingMode mode)
		{
			var entry = EnumUtility.GetEnumEntry(member as Enum);
			this.Name = !string.IsNullOrEmpty(entry.Alias) ? entry.Alias : entry.Name;
			this.Member = member;
			this.Mode = mode;
		}

		#endregion
	}
}
