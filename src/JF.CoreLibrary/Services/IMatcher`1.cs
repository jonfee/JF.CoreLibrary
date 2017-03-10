using System;
using System.Collections.Generic;

namespace JF.Services
{
	public interface IMatcher<T> : IMatcher
	{
		bool Match(object target, T parameter);
	}
}