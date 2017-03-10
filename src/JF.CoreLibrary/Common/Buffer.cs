using System;
using System.IO;

namespace JF.Common
{
	public class Buffer
	{
		#region 成员字段

		private byte[] _value;
		private int _offset;
		private int _count;
		private int _position;

		#endregion

		#region 构造方法

		public Buffer(byte[] value) : this(value, 0, -1)
		{
		}

		public Buffer(byte[] value, int offset) : this(value, offset, -1)
		{
		}

		public Buffer(byte[] value, int offset, int count)
		{
			if(value == null)
			{
				throw new ArgumentNullException("value");
			}

			if(offset < 0 || offset >= value.Length)
			{
				throw new ArgumentOutOfRangeException("offset");
			}

			if(count < 0)
			{
				count = value.Length - offset;
			}

			if(offset + count > value.Length)
			{
				throw new ArgumentOutOfRangeException("count");
			}

			_value = value;
			_offset = offset;
			_count = count;
		}

		#endregion

		#region 公共属性

		public byte[] Value
		{
			get
			{
				return _value;
			}
		}

		public int Offset
		{
			get
			{
				return _offset;
			}
		}

		public int Count
		{
			get
			{
				return _count;
			}
		}

		public int Position
		{
			get
			{
				return _position;
			}
		}

		#endregion

		#region 公共方法

		public bool CanRead()
		{
			return _position < _count;
		}

		public int Read(Stream stream, int count)
		{
			if(stream == null)
			{
				throw new ArgumentNullException("stream");
			}

			if(count < 1)
			{
				return 0;
			}

			int position = _position;
			int availableLength = Math.Min(count, _count - position);

			if(availableLength > 0)
			{
				stream.Write(_value, _offset + position, availableLength);
				_position = position + availableLength;
			}

			return availableLength;
		}

		public int Read(byte[] buffer, int offset, int count)
		{
			if(buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}

			if(offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset");
			}

			if(count < 1 || offset + count > buffer.Length)
			{
				return 0;
			}

			int position = _position;
			int availableLength = Math.Min(count, _count - position);

			if(availableLength > 0)
			{
				System.Buffer.BlockCopy(_value, _offset + position, buffer, offset, availableLength);
				_position = position + availableLength;
			}

			return availableLength;
		}

		#endregion
	}
}