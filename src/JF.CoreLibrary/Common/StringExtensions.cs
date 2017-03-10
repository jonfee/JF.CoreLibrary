using System;
using System.Collections.Generic;
using System.Linq;

namespace JF.Common
{
	public static class StringExtensions
	{
		public static readonly string InvalidCharacters = "`~!@#$%^&*()-+={}[]|\\/?:;'\"\t\r\n ";

		#region 实用方法

		public static int GetStringHashCode(string text)
		{
			if(text == null || text.Length < 1)
				return 0;

			unsafe
			{
				fixed(char* src = text)
				{
					int hash1 = 5381;
					int hash2 = hash1;

					int c;
					char* s = src;
					while((c = s[0]) != 0)
					{
						hash1 = ((hash1 << 5) + hash1) ^ c;
						c = s[1];

						if(c == 0)
							break;

						hash2 = ((hash2 << 5) + hash2) ^ c;
						s += 2;
					}

					return hash1 + (hash2 * 1566083941);
				}
			}
		}

		public static bool ContainsCharacters(this string text, string characters)
		{
			if(string.IsNullOrEmpty(text) || string.IsNullOrEmpty(characters))
				return false;

			return ContainsCharacters(text, characters.ToArray());
		}

		public static bool ContainsCharacters(this string text, params char[] characters)
		{
			if(string.IsNullOrEmpty(text) || characters.Length < 1)
				return false;

			foreach(char character in characters)
			{
				foreach(char item in text)
				{
					if(character == item)
						return true;
				}
			}

			return false;
		}

		public static string RemoveCharacters(this string text, string invalidCharacters)
		{
			return RemoveCharacters(text, invalidCharacters, 0);
		}

		public static string RemoveCharacters(this string text, char[] invalidCharacters)
		{
			return RemoveCharacters(text, invalidCharacters, 0);
		}

		public static string RemoveCharacters(this string text, string invalidCharacters, int startIndex)
		{
			return RemoveCharacters(text, invalidCharacters, startIndex, -1);
		}

		public static string RemoveCharacters(this string text, char[] invalidCharacters, int startIndex)
		{
			return RemoveCharacters(text, invalidCharacters, startIndex, -1);
		}

		public static string RemoveCharacters(this string text, string invalidCharacters, int startIndex, int count)
		{
			return RemoveCharacters(text, invalidCharacters.ToCharArray(), startIndex, count);
		}

		public static string RemoveCharacters(this string text, char[] invalidCharacters, int startIndex, int count)
		{
			if(string.IsNullOrEmpty(text) || invalidCharacters.Length < 1)
				return text;

			if(startIndex < 0)
				throw new ArgumentOutOfRangeException("startIndex");

			if(count < 1)
				count = invalidCharacters.Length - startIndex;

			if(startIndex + count > invalidCharacters.Length)
				throw new ArgumentOutOfRangeException("count");

			string result = text;

			for(int i = startIndex; i < startIndex + count; i++)
				result = result.Replace(invalidCharacters[i].ToString(), "");

			return result;
		}

		public static string TrimString(this string text, string trimString)
		{
			return TrimString(text, trimString, StringComparison.OrdinalIgnoreCase);
		}

		public static string TrimString(this string text, string trimString, StringComparison comparisonType)
		{
			return TrimStringEnd(TrimStringStart(text, trimString, comparisonType), trimString, comparisonType);
		}

		public static string TrimString(this string text, string prefix, string suffix)
		{
			return TrimString(text, prefix, suffix, StringComparison.OrdinalIgnoreCase);
		}

		public static string TrimString(this string text, string prefix, string suffix, StringComparison comparisonType)
		{
			return text.TrimStringStart(prefix, comparisonType).TrimStringEnd(suffix, comparisonType);
		}

		public static string TrimStringEnd(this string text, string trimString)
		{
			return TrimStringEnd(text, trimString, StringComparison.OrdinalIgnoreCase);
		}

		public static string TrimStringEnd(this string text, string trimString, StringComparison comparisonType)
		{
			if(string.IsNullOrEmpty(text) || string.IsNullOrEmpty(trimString))
				return text;

			while(text.EndsWith(trimString, comparisonType))
				text = text.Remove(text.Length - trimString.Length);

			return text;
		}

		public static string TrimStringStart(this string text, string trimString)
		{
			return TrimStringStart(text, trimString, StringComparison.OrdinalIgnoreCase);
		}

		public static string TrimStringStart(this string text, string trimString, StringComparison comparisonType)
		{
			if(string.IsNullOrEmpty(text) || string.IsNullOrEmpty(trimString))
				return text;

			while(text.StartsWith(trimString, comparisonType))
				text = text.Remove(0, trimString.Length);

			return text;
		}

		public static bool In(this string text, IEnumerable<string> collection, StringComparison comparisonType)
		{
			if(collection == null)
				return false;

			return collection.Any(item => string.Equals(item, text, comparisonType));
		}

		#endregion

		#region 类型转换

		public static bool ToBoolean(this string text)
		{
			return Convert.ConvertValue<bool>(text);
		}

		public static bool ToBoolean(this string text, bool defaultValue)
		{
			return Convert.ConvertValue<bool>(text, defaultValue);
		}

		public static byte ToByte(this string text)
		{
			return Convert.ConvertValue<byte>(text);
		}

		public static byte ToByte(this string text, byte defaultValue)
		{
			return Convert.ConvertValue<byte>(text, defaultValue);
		}

		public static sbyte ToSByte(this string text)
		{
			return Convert.ConvertValue<sbyte>(text);
		}

		public static sbyte ToSByte(this string text, sbyte defaultValue)
		{
			return Convert.ConvertValue<sbyte>(text, defaultValue);
		}

		public static char ToChar(this string text)
		{
			return Convert.ConvertValue<char>(text);
		}

		public static char ToChar(this string text, char defaultValue)
		{
			return Convert.ConvertValue<char>(text, defaultValue);
		}

		public static DateTime ToDateTime(this string text)
		{
			return Convert.ConvertValue<DateTime>(text);
		}

		public static DateTime ToDateTime(this string text, DateTime defaultValue)
		{
			return Convert.ConvertValue<DateTime>(text, defaultValue);
		}

		public static decimal ToDecimal(this string text)
		{
			return Convert.ConvertValue<decimal>(text);
		}

		public static decimal ToDecimal(this string text, decimal defaultValue)
		{
			return Convert.ConvertValue<decimal>(text, defaultValue);
		}

		public static float ToSingle(this string text)
		{
			return Convert.ConvertValue<float>(text);
		}

		public static float ToSingle(this string text, float defaultValue)
		{
			return Convert.ConvertValue<float>(text, defaultValue);
		}

		public static double ToDouble(this string text)
		{
			return Convert.ConvertValue<double>(text);
		}

		public static double ToDouble(this string text, double defaultValue)
		{
			return Convert.ConvertValue<double>(text, defaultValue);
		}

		public static short ToInt16(this string text)
		{
			return Convert.ConvertValue<short>(text);
		}

		public static short ToInt16(this string text, short defaultValue)
		{
			return Convert.ConvertValue<short>(text, defaultValue);
		}

		public static ushort ToUInt16(this string text)
		{
			return Convert.ConvertValue<ushort>(text);
		}

		public static ushort ToUInt16(this string text, ushort defaultValue)
		{
			return Convert.ConvertValue<ushort>(text, defaultValue);
		}

		public static int ToInt32(this string text)
		{
			return Convert.ConvertValue<int>(text);
		}

		public static int ToInt32(this string text, int defaultValue)
		{
			return Convert.ConvertValue<int>(text, defaultValue);
		}

		public static uint ToUInt32(this string text)
		{
			return Convert.ConvertValue<uint>(text);
		}

		public static uint ToUInt32(this string text, uint defaultValue)
		{
			return Convert.ConvertValue<uint>(text, defaultValue);
		}

		public static long ToInt64(this string text)
		{
			return Convert.ConvertValue<long>(text);
		}

		public static long ToInt64(this string text, long defaultValue)
		{
			return Convert.ConvertValue<long>(text, defaultValue);
		}

		public static ulong ToUInt64(this string text)
		{
			return Convert.ConvertValue<ulong>(text);
		}

		public static ulong ToUInt64(this string text, ulong defaultValue)
		{
			return Convert.ConvertValue<ulong>(text, defaultValue);
		}

		#endregion
	}
}