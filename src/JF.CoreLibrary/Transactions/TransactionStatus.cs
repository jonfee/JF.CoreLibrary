using System;
using System.ComponentModel;

namespace JF.Transactions
{
	/// <summary>
	/// 表示事务状态的枚举。
	/// </summary>
	public enum TransactionStatus
	{
		/// <summary>事务活动中。</summary>
		Active,

		/// <summary>事务已回滚。</summary>
		Aborted,

		/// <summary>事务已提交。</summary>
		Committed,

		/// <summary>事务的状态未知。</summary>
		Undetermined
	}
}