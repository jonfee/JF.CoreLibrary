using System;
using System.Collections.Generic;

namespace JF.Diagnostics
{
	public class LoggerHandlerCollection : JF.Collections.NamedCollectionBase<LoggerHandler>
	{
		#region 构造方法

		public LoggerHandlerCollection() : base(StringComparer.OrdinalIgnoreCase)
		{
		}

		#endregion

		#region 重写方法

		protected override string GetKeyForItem(LoggerHandler item)
		{
			return item.Name;
		}

		#endregion
	}
}