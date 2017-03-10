using System;
using System.Collections;
using System.Collections.Generic;

namespace JF.Collections
{
	public static class DictionaryExtension
	{
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		public static bool TryGetValue(this IDictionary dictionary, object key, out object value)
		{
			value = null;

			if(dictionary == null || dictionary.Count < 1)
			{
				return false;
			}

			var existed = dictionary.Contains(key);

			if(existed)
			{
				value = dictionary[key];
			}

			return existed;
		}

		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		public static bool TryGetValue(this IDictionary dictionary, object key, Action<object> onGot)
		{
			if(dictionary == null || dictionary.Count < 1)
			{
				return false;
			}

			var existed = dictionary.Contains(key);

			if(existed && onGot != null)
			{
				onGot(dictionary[key]);
			}

			return existed;
		}

		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		public static bool TryGetValue<TValue>(this IDictionary dictionary, object key, out TValue value)
		{
			value = default(TValue);

			if(dictionary == null || dictionary.Count < 1)
			{
				return false;
			}

			var existed = dictionary.Contains(key);

			if(existed)
			{
				value = JF.Common.Convert.ConvertValue<TValue>(dictionary[key]);
			}

			return existed;
		}

		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		public static bool TryGetValue<TValue>(this IDictionary dictionary, object key, Action<object> onGot)
		{
			if(dictionary == null || dictionary.Count < 1)
			{
				return false;
			}

			var existed = dictionary.Contains(key);

			if(existed && onGot != null)
			{
				onGot(JF.Common.Convert.ConvertValue<TValue>(dictionary[key]));
			}

			return existed;
		}

		public static bool TryGetValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Action<TValue> onGot)
		{
			if(dictionary == null || dictionary.Count < 1)
			{
				return false;
			}

			TValue value;

			if(dictionary.TryGetValue(key, out value) && onGot != null)
			{
				onGot(value);
				return true;
			}

			return false;
		}

		public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IDictionary dictionary, Func<object, TKey> keyConvert = null, Func<object, TValue> valueConvert = null)
		{
			if(dictionary == null)
			{
				return null;
			}

			if(keyConvert == null)
			{
				keyConvert = key => JF.Common.Convert.ConvertValue<TKey>(key);
			}

			if(valueConvert == null)
			{
				valueConvert = value => JF.Common.Convert.ConvertValue<TValue>(value);
			}

			var result = new Dictionary<TKey, TValue>(dictionary.Count);

			foreach(DictionaryEntry entry in dictionary)
			{
				result.Add(keyConvert(entry.Key), valueConvert(entry.Value));
			}

			return result;
		}
	}
}