using System;
using System.Collections.Generic;

namespace JF.Services
{
	public interface IServiceLifetime
	{
		bool IsAlive(ServiceEntry entry);
	}
}