using System;
using System.Collections.Generic;

namespace JF.Collections
{
	public interface IQueueProvider
	{
		IQueue GetQueue(string name);
	}
}