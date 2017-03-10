using System;
using System.Collections.Generic;

namespace JF.Services
{
	public interface IMatcher
	{
		bool Match(object target, object parameter);
	}
}