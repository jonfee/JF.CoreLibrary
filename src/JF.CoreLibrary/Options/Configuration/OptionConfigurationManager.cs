using System;
using System.IO;
using System.Collections.Generic;

namespace JF.Options.Configuration
{
	public static class OptionConfigurationManager
	{
		#region 私有变量

		private readonly static JF.Collections.ObjectCache<OptionConfiguration> _cache = new Collections.ObjectCache<OptionConfiguration>(0);

		#endregion

		#region 公共方法

		public static OptionConfiguration Open(string filePath, bool createNotExists = false)
		{
			if(string.IsNullOrWhiteSpace(filePath))
			{
				throw new ArgumentNullException("filePath");
			}

			return _cache.Get(filePath.Trim(), key =>
			{
				if(File.Exists(key))
				{
					return OptionConfiguration.Load(key);
				}

				if(createNotExists)
				{
					return new OptionConfiguration(key);
				}

				return null;
			});
		}

		public static void Close(string filePath)
		{
			if(string.IsNullOrWhiteSpace(filePath))
			{
				return;
			}

			_cache.Remove(filePath.Trim());
		}

		#endregion
	}
}