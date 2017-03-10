using System;
using System.Collections.Generic;

namespace JF.Reporting
{
	public interface IReportView
	{
		void Render(IReport report);
	}
}