using System;
using System.Collections.Generic;

namespace JF.Runtime.Caching
{
	internal static class BufferUtility
	{
		#region 常量定义

		public const int KB = 1024;
		public const int MB = 1024 * KB;
		public const int GB = 1024 * MB;

		public const int Kilobytes = KB;
		public const int Megabytes = MB;
		public const int Gigabytes = GB;

		#endregion

		private static readonly DateTime BaseTimestamp = new DateTime(2000, 1, 1);

		public static uint GetTimestamp()
		{
			return (uint)(DateTime.Now - BaseTimestamp).TotalSeconds;
		}

		public static TimeSpan GetTimestampSpan(uint timestamp)
		{
			return TimeSpan.FromSeconds(GetTimestamp() - timestamp);
		}
	}
}