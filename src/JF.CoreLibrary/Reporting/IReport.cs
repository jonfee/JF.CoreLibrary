using System;
using System.Collections.Generic;

namespace JF.Reporting
{
	public interface IReport
	{
		/// <summary>
		/// 获取报表的名称。
		/// </summary>
		string Name
		{
			get;
		}

		/// <summary>
		/// 获取或设置报表的显式标题。
		/// </summary>
		string Title
		{
			get;
			set;
		}

		/// <summary>
		/// 获取报表的参数集。
		/// </summary>
		IDictionary<string, object> Parameters
		{
			get;
		}

		/// <summary>
		/// 获取或设置报表的数据源。
		/// </summary>
		object DataSource
		{
			get;
			set;
		}
	}
}