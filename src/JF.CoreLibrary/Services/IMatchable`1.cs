using System;

namespace JF.Services
{
	public interface IMatchable<T> : IMatchable
	{
		bool IsMatch(T parameter);
	}
}