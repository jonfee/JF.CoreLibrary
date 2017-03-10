using System;
using System.ComponentModel;

namespace JF.Runtime.Serialization
{
	[Flags]
	public enum SerializationBehavior
	{
		None = 0,
		IgnoreDefaultValue = 1,
	}
}