using System;
using System.ComponentModel;
using JF.ComponentModel;

namespace JF.Data
{
	/// <summary>
	/// 表示条件筛选操作符。
	/// </summary>
	public enum ConditionOperator
	{
		/// <summary>
		/// 等于。
		/// </summary>
		[Alias("=")]
		[Description("等于")]
		Equals,

		/// <summary>
		/// 不等于。
		/// </summary>
		[Alias("!=")]
		[Description("不等于")]
		NotEqual,

		/// <summary>
		/// 大于。
		/// </summary>
		[Alias(">")]
		[Description("大于")]
		GreaterThan,

		/// <summary>
		/// 大于等于。
		/// </summary>
		[Alias(">=")]
		[Description("大于等于")]
		GreaterThanOrEqual,

		/// <summary>
		/// 小于。
		/// </summary>
		[Alias("<")]
		[Description("小于")]
		LessThan,

		/// <summary>
		/// 小于等于。
		/// </summary>
		[Alias("<=")]
		[Description("小于等于")]
		LessThanOrEqual,

		/// <summary>
		/// 包含。
		/// </summary>
		[Alias("like")]
		[Description("包含")]
		Like,

		/// <summary>
		/// 范围。
		/// </summary>
		[Alias("in")]
		[Description("范围")]
		In,

		/// <summary>
		/// 范围。
		/// </summary>
		[Alias("notin")]
		[Description("范围")]
		NotIn,

		/// <summary>
		/// 为空。
		/// </summary>
		[Alias("isnull")]
		[Description("为空")]
		IsNull,

		/// <summary>
		/// 为空。
		/// </summary>
		[Alias("notnull")]
		[Description("不为空")]
		IsNotNull
	}
}