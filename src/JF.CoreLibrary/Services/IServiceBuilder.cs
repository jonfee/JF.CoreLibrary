using System;
using System.Collections.Generic;

namespace JF.Services
{
	public interface IServiceBuilder
	{
		object Build(ServiceEntry entry);
	}
}