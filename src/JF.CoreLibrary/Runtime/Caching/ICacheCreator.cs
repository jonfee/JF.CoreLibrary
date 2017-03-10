using System;
using System.Collections.Generic;

namespace JF.Runtime.Caching
{
	public interface ICacheCreator
	{
		object Create(string cacheName, string key, out TimeSpan duration);
	}
}