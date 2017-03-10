using System;
using System.Collections.Generic;

namespace JF.Data
{
	public class ConditionCollection : JF.Collections.Collection<ICondition>, ICondition
	{
		#region 成员字段

		private ConditionCombination _conditionCombination;

		#endregion

		#region 公共属性

		/// <summary>
		/// 获取或设置查询条件的组合方式。
		/// </summary>
		public ConditionCombination ConditionCombination
		{
			get
			{
				return _conditionCombination;
			}
			set
			{
				_conditionCombination = value;
			}
		}

		#endregion

		#region 构造方法

		public ConditionCollection() : this(ConditionCombination.And)
		{
		}

		public ConditionCollection(ConditionCombination conditionCombination)
		{
			_conditionCombination = conditionCombination;
		}

		public ConditionCollection(ConditionCombination conditionCombination, IEnumerable<ICondition> items) : base(items)
		{
			_conditionCombination = conditionCombination;
		}

		public ConditionCollection(ConditionCombination conditionCombination, params ICondition[] items) : base(items)
		{
			_conditionCombination = conditionCombination;
		}

		#endregion
	}
}