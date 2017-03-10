using System;
using JF.Common;

namespace JF.Data
{
	/// <summary>
	/// 表示数据过滤条件的设置项。
	/// </summary>
	/// <typeparam name="T">枚举类型。</typeparam>
	public class Condition<T> : Condition where T : struct
	{
		#region 公共属性

		/// <summary>
		/// 获取条件成员。
		/// </summary>
		public T Member
		{
			get;
			private set;
		}

		#endregion

		#region 构造方法

		/// <summary>
		/// 初始化 <see cref="Condition"/> 类的新实例。
		/// </summary>
		/// <param name="member">条件成员。</param>
		/// <param name="value">条件值。</param>
		public Condition(T member, object value) : this(member, ConditionOperator.Equals, value)
		{

		}

		/// <summary>
		/// 初始化 <see cref="Condition"/> 类的新实例。 
		/// </summary>
		/// <param name="member">枚举项。</param>
		/// <param name="operator">操作符。</param>
		/// <param name="value">条件值。</param>
		public Condition(T member, ConditionOperator @operator, object value = null)
		{
			if(value == null && @operator != ConditionOperator.IsNull && @operator != ConditionOperator.IsNotNull)
				throw new ArgumentNullException(nameof(value));

			var entry = EnumUtility.GetEnumEntry(member as Enum);
			this.Name = !string.IsNullOrEmpty(entry.Alias) ? entry.Alias : entry.Name;

			this.Member = member;
			this.Operator = @operator;
			this.Value = value;
		}

		#endregion
	}
}
