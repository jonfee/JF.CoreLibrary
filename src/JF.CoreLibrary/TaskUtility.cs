using System;
using System.Threading.Tasks;

namespace JF
{
	internal static class TaskUtility
	{
		public static T ExecuteTask<T>(Func<Task<T>> thunk)
		{
			return Task.Run(() => ExecuteTaskDelegate(() => thunk())).Result;
		}

		private static async Task<T> ExecuteTaskDelegate<T>(Func<Task<T>> thunk)
		{
			return await thunk();
		}
	}
}