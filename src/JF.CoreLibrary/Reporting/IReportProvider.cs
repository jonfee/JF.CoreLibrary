using System;
using System.Collections.Generic;

namespace JF.Reporting
{
	public interface IReportProvider
	{
		IReport GetReport(string name);

		IEnumerable<IReport> GetReports();
	}
}