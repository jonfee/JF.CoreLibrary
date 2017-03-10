using System;
using System.Collections.Generic;

namespace JF.Options
{
	public interface IOptionLoaderSelector
	{
		IOptionLoader GetLoader(IOptionProvider provider);
	}
}