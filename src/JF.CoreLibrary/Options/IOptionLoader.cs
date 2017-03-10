using System;
using System.Collections.Generic;

namespace JF.Options
{
	public interface IOptionLoader
	{
		void Load(IOptionProvider provider);

		void Unload(IOptionProvider provider);
	}
}