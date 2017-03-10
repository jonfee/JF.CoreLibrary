using System;
using System.ComponentModel;

namespace JF.Transactions
{
	/// <summary>
	/// 表示当前事务处理程序所处的阶段。
	/// </summary>
	public enum EnlistmentPhase
	{
		/// <summary>准备阶段，表示当前事务被启动。</summary>
		Prepare,

		/// <summary>提交阶段，表示事务被显式提交。</summary>
		Commit,

		/// <summary>回滚阶段，表示事务被回滚。</summary>
		Rollback,

		/// <summary>终止阶段，表示事务因为异常或者被手动终止。</summary>
		Abort,
	}
}