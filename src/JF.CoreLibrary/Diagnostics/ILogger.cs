using System;
using System.Collections.Generic;

namespace JF.Diagnostics
{
	public interface ILogger
	{
		void Log(LogEntry entry);
	}
}