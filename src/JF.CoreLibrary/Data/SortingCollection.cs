using System;
using System.Collections.Generic;

namespace JF.Data
{
	public class SortingCollection : JF.Collections.Collection<Sorting>, ISorting
	{
		#region 构造方法

		public SortingCollection()
		{

		}

		public SortingCollection(IEnumerable<Sorting> items) : base(items)
		{

		}

		#endregion
	}
}
