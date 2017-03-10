using System;
using System.Collections.Generic;
using JF.Options;
using JF.Options.Configuration;

namespace JF.Communication.Net.Configuration
{
	public class FtpUserOptionElementCollection : OptionConfigurationElementCollection<FtpUserOptionElement>
	{
		#region 构造方法

		public FtpUserOptionElementCollection() : base("user")
		{
		}

		#endregion
	}
}