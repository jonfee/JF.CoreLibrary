using System;
using System.Collections.Generic;

namespace JF.Options
{
	public interface IOptionView
	{
		IOption Option
		{
			get;
		}

		bool IsUsable
		{
			get;
		}
	}
}