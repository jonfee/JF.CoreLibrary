using System;
using System.Collections.Generic;

namespace JF.Common
{
	public static class ObjectExtensions
	{
		#region 类型转换

		public static T ConvertTo<T>(this object value)
		{
			return Convert.ConvertValue<T>(value);
		}

		public static T ConvertTo<T>(this object value, T defaultValue)
		{
			return Convert.ConvertValue<T>(value, defaultValue);
		}

		public static T ConvertTo<T>(this object value, Func<object> defaultValueThunk)
		{
			return Convert.ConvertValue<T>(value, defaultValueThunk);
		}

		public static object ConvertTo(this object value, Type conversionType)
		{
			return Convert.ConvertValue(value, conversionType);
		}

		public static object ConvertTo(this object value, Type conversionType, object defaultValue)
		{
			return Convert.ConvertValue(value, conversionType, defaultValue);
		}

		public static object ConvertTo(this object value, Type conversionType, Func<object> defaultValueThunk)
		{
			return Convert.ConvertValue(value, conversionType, defaultValueThunk);
		}

		public static bool TryConvertTo<T>(this object value, out T result)
		{
			return Convert.TryConvertValue<T>(value, out result);
		}

		public static bool TryConvertTo(object value, Type conversionType, out object result)
		{
			return Convert.TryConvertValue(value, conversionType, out result);
		}

		#endregion
	}
}