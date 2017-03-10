using System;

namespace JF.Options.Configuration
{
	[Flags]
	public enum OptionConfigurationPropertyBehavior
	{
		None = 0,
		IsKey = 3,
		IsRequired = 1,
	}
}