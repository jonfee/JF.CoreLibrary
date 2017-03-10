using System;

namespace JF.Communication.Net
{
	internal class BufferEvaluator
	{
		#region 常量定义

		public const int KB = 1024;
		public const int MB = 1024 * KB;
		public const int GB = 1024 * MB;

		#endregion

		#region 单例模式

		public static readonly BufferEvaluator Default = new BufferEvaluator();

		#endregion

		#region 成员字段

		private int _minimum;

		#endregion

		#region 构造方法

		public BufferEvaluator()
		{
			_minimum = 1024;
		}

		#endregion

		#region 公共属性

		public int Minimum
		{
			get
			{
				return _minimum;
			}
			set
			{
				if(value < 0)
				{
					throw new ArgumentOutOfRangeException();
				}

				_minimum = value;
			}
		}

		#endregion

		#region 公共方法

		public int GetBufferSize(long size)
		{
			if(size < 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}

			return Math.Max(_minimum, this.Evaluate(size));
		}

		#endregion

		#region 虚拟方法

		protected virtual int Evaluate(long size)
		{
			if(size < 32 * KB)
			{
				return KB;
			}

			if(size < 256 * KB)
			{
				return 16 * KB;
			}

			if(size < MB)
			{
				return 32 * KB;
			}

			if(size < 5 * MB)
			{
				return 64 * KB;
			}

			if(size < 10 * MB)
			{
				return 128 * KB;
			}

			if(size < 50 * MB)
			{
				return 256 * KB;
			}

			if(size < 100 * MB)
			{
				return 512 * KB;
			}

			return MB;
		}

		#endregion
	}
}