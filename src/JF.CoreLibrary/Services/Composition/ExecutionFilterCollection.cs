using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace JF.Services.Composition
{
	public class ExecutionFilterCollection : JF.Collections.NamedCollectionBase<IExecutionFilter>
	{
		#region 构造方法

		public ExecutionFilterCollection()
		{
		}

		#endregion

		#region 重写方法

		protected override string GetKeyForItem(IExecutionFilter item)
		{
			return item.Name;
		}

		#endregion
	}
}