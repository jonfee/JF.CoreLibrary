using System;
using System.Collections.Generic;
using JF.Options;
using JF.Options.Configuration;

namespace JF.Diagnostics.Configuration
{
	public class LoggerHandlerElementCollection : OptionConfigurationElementCollection<LoggerHandlerElement>
	{
		#region 构造方法

		public LoggerHandlerElementCollection() : base("handler")
		{
		}

		#endregion

		#region 重写函数

		protected override OptionConfigurationElement CreateNewElement()
		{
			return new LoggerHandlerElement();
		}

		protected override string GetElementKey(OptionConfigurationElement element)
		{
			return ((LoggerHandlerElement)element).Name;
		}

		#endregion
	}
}