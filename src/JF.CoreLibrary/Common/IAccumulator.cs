using System;

namespace JF.Common
{
	/// <summary>
	/// 提供数值递增和递减的功能。
	/// </summary>
	public interface IAccumulator
	{
		long Increment(string key, int interval = 1);

		long Decrement(string key, int interval = 1);
	}
}