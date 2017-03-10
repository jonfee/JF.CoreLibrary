using System;
using System.Collections.Generic;

namespace JF.Transactions
{
	public interface IEnlistment
	{
		void OnEnlist(EnlistmentContext context);
	}
}