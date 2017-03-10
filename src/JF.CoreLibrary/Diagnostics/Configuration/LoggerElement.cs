using System;
using System.Collections.Generic;
using JF.Options;
using JF.Options.Configuration;

namespace JF.Diagnostics.Configuration
{
	public class LoggerElement : OptionConfigurationElement
	{
		#region 公共属性

		[OptionConfigurationProperty("")]
		public LoggerHandlerElementCollection Handlers
		{
			get
			{
				return (LoggerHandlerElementCollection)this[""];
			}
		}

		#endregion
	}
}