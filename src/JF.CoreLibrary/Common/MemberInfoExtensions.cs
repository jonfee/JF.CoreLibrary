using System;
using System.Reflection;

namespace JF.Common
{
	public static class MemberInfoExtensions
	{
		public static bool IsField(this MemberInfo member)
		{
			return member.MemberType == MemberTypes.Field;
		}

		public static bool IsProperty(this MemberInfo member)
		{
			return member.MemberType == MemberTypes.Property;
		}

		public static bool IsMethod(this MemberInfo member)
		{
			return member.MemberType == MemberTypes.Method;
		}
	}
}