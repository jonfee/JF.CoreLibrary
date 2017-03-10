using System;
using System.Collections.Generic;

namespace JF.Transactions
{
	public class EnlistmentContext
	{
		#region 成员字段

		private EnlistmentPhase _phase;
		private Transaction _transaction;

		#endregion

		#region 构造方法

		internal EnlistmentContext(Transaction transaction, EnlistmentPhase phase)
		{
			if(transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}

			_transaction = transaction;
			_phase = phase;
		}

		#endregion

		#region 公共属性

		/// <summary>
		/// 获取当前事务阶段。
		/// </summary>
		public EnlistmentPhase Phase
		{
			get
			{
				return _phase;
			}
		}

		/// <summary>
		/// 获取当前的事务对象。
		/// </summary>
		public Transaction Transaction
		{
			get
			{
				return _transaction;
			}
		}

		#endregion

		#region 公共方法

		/// <summary>
		/// 将当前事务更改为跟随父事务。
		/// </summary>
		/// <returns></returns>
		public bool Follow()
		{
			var parent = _transaction.Parent;

			if(parent == null)
			{
				return false;
			}

			switch(this.Phase)
			{
				case EnlistmentPhase.Abort:
					parent.Operation = Transaction.OPERATION_ABORT;
					break;
				case EnlistmentPhase.Rollback:
					parent.Operation = Transaction.OPERATION_ROLLBACK;
					break;
			}

			return true;
		}

		#endregion
	}
}