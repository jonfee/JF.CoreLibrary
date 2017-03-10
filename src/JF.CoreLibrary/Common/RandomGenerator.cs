﻿using System;
using System.Security.Cryptography;

namespace JF.Common
{
	public static class RandomGenerator
	{
		#region 常量定义

		private const string Digits = "0123456789ABCDEFGHJKMNPRSTUVWXYZ";
		private static readonly System.Security.Cryptography.RandomNumberGenerator _random = System.Security.Cryptography.RandomNumberGenerator.Create();

		#endregion

		#region 公共方法

		public static byte[] Generate(int length)
		{
			if(length < 1)
			{
				throw new ArgumentOutOfRangeException("length");
			}

			var bytes = new byte[length];
			_random.GetBytes(bytes);
			return bytes;
		}

		public static int GenerateInt32()
		{
			var bytes = new byte[4];
			_random.GetBytes(bytes);
			return BitConverter.ToInt32(bytes, 0);
		}

		public static long GenerateInt64()
		{
			var bytes = new byte[8];
			_random.GetBytes(bytes);
			return BitConverter.ToInt64(bytes, 0);
		}

		public static string GenerateString()
		{
			return GenerateString(8);
		}

		public static string GenerateString(int length, bool digitOnly = false)
		{
			if(length < 1 || length > 128)
			{
				throw new ArgumentOutOfRangeException("length");
			}

			var result = new char[length];
			var data = new byte[length];

			_random.GetBytes(data);

			//确保首位字符始终为数字字符
			result[0] = Digits[data[0] % 10];

			for(int i = 1; i < length; i++)
			{
				result[i] = Digits[data[i] % (digitOnly ? 10 : 32)];
			}

			return new string(result);
		}

		[Obsolete]
		public static string GenerateStringEx(int length = 8)
		{
			if(length < 1 || length > 128)
			{
				throw new ArgumentOutOfRangeException("length");
			}

			var result = new char[length];
			var data = new byte[(int)Math.Ceiling((length * 5) / 8.0)];

			_random.GetBytes(data);

			int value;

			for(int i = 0; i < length; i++)
			{
				int index = i * 5 / 8;
				var bitCount = i * 5 % 8; //当前字节中已获取的位数
				var takeCount = 8 - bitCount;

				if(takeCount < 5)
				{
					value = (((byte)(255 << bitCount)) & data[index]) >> bitCount;
					var count = 8 - (5 - takeCount);
					value += ((byte)(data[index + 1] << count) >> (count - takeCount));
				}
				else
				{
					value = data[index] & (((255 >> (takeCount - 5)) - (255 >> takeCount)) >> bitCount);
				}

				result[i] = Digits[value % 32];
			}

			return new string(result);
		}

		#endregion
	}
}