using System;
using System.ComponentModel;

namespace JF.Data
{
	/// <summary>
	/// 表示筛选条件的组合方式。
	/// </summary>
	public enum ConditionCombination
	{
		/// <summary>
		/// 条件“与”组合。
		/// </summary>
		[Description("并且")]
		And,

		/// <summary>
		/// 条件“或”组合。
		/// </summary>
		[Description("或者")]
		Or
	}
}
