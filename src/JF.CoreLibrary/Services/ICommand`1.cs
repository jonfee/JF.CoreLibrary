using System;

namespace JF.Services
{
	public interface ICommand<in TContext> : ICommand
	{
		bool CanExecute(TContext context);

		object Execute(TContext context);
	}
}