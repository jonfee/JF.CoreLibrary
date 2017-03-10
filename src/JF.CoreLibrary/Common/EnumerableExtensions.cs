using System;
using System.Collections.Generic;
using System.Linq;

namespace JF.Common
{
	public static class EnumerableExtensions
	{
		public static bool HasValue<T>(this IEnumerable<T> source)
		{
			return source != null && source.Any();
		}

		public static IEnumerable<T> Select<T>(this IEnumerable<T> source, int pageIndex, int pageSize)
		{
			if(source == null)
				throw new ArgumentNullException(nameof(source));

			var pageCount = 0;
			var recordCount = 0;

			return source.Select(pageIndex, pageSize, out pageCount, out recordCount);
		}

		public static IEnumerable<T> Select<T>(this IEnumerable<T> source, int pageIndex, int pageSize, out int pageCount, out int recordCount)
		{
			if(source == null)
				throw new ArgumentNullException(nameof(source));

			recordCount = source.Count();
			pageCount = (int)Math.Ceiling((decimal)recordCount / pageSize);

			var result = source.Skip((pageIndex - 1) * pageSize).Take(pageSize);

			return result;
		}
	}
}
