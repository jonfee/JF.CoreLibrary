using System;
using System.Collections.Generic;

namespace JF.Common
{
	public interface IUnitOfWork
	{
		#region 公共属性

		/// <summary>
		///  获得一个值，该值表示是否支持分布式事务处理机制。
		/// </summary>
		bool DistributedTransactionSupported
		{
			get;
		}

		/// <summary>
		/// 获得一个值，该值表述了当前事务是否已被提交。
		/// </summary>
		bool IsCompleted
		{
			get;
		}

		#endregion

		#region 公共方法

		/// <summary>
		/// 提交当前事务。
		/// </summary>
		void Commit();

		/// <summary>
		/// 回滚当前事务。
		/// </summary>
		void Rollback();

		#endregion
	}
}
