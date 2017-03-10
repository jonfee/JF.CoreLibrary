using System;
using System.Collections.Generic;

namespace JF.Transactions
{
	public class TransactionInformation
	{
		#region 成员字段

		private Guid _transactionId;
		private Transaction _transaction;
		private IDictionary<string, object> _parameters;

		#endregion

		#region 构造方法

		public TransactionInformation(Transaction transaction)
		{
			if(transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}

			_transaction = transaction;
			_transactionId = Guid.NewGuid();
		}

		#endregion

		#region 公共属性

		/// <summary>
		/// 获取当前事务的唯一编号。
		/// </summary>
		public Guid TransactionId
		{
			get
			{
				return _transactionId;
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

		/// <summary>
		/// 获取当前事务对象的父事务，如果当前事务是根事务则返回空(null)。
		/// </summary>
		public Transaction Parent
		{
			get
			{
				return _transaction.Parent;
			}
		}

		/// <summary>
		/// 获取当前事务的行为特性。
		/// </summary>
		public TransactionBehavior Behavior
		{
			get
			{
				return _transaction.Behavior;
			}
		}

		/// <summary>
		/// 获取当前事务的状态。
		/// </summary>
		public TransactionStatus Status
		{
			get
			{
				return _transaction.Status;
			}
		}

		/// <summary>
		/// 获取当前事务的环境参数。
		/// </summary>
		public IDictionary<string, object> Parameters
		{
			get
			{
				if(_parameters == null)
				{
					System.Threading.Interlocked.CompareExchange(ref _parameters, new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase), null);
				}

				return _parameters;
			}
		}

		#endregion
	}
}