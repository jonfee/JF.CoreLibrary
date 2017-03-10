using System;
using System.ComponentModel;

namespace JF.Runtime.Serialization
{
	[Flags]
	public enum SerializationMembers
	{
		All = 3,
		Properties = 1,
		Fields = 2,
	}
}