using System;
using System.ComponentModel;

namespace JF.Transactions
{
	/// <summary>
	/// 表示事务的传播行为(范围)的枚举。
	/// </summary>
	public enum TransactionBehavior
	{
		Followed,
		Required,
		RequiresNew,
		Suppress,
	}
}