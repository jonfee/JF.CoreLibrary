using System;
using System.Collections.Generic;

namespace JF.Runtime.Serialization
{
	public class SerializationWritingEventArgs : SerializationWroteEventArgs
	{
		#region 成员字段

		private bool _cancel;

		#endregion

		#region 构造方法

		public SerializationWritingEventArgs(SerializationWriterContext context) : this(context, false)
		{
		}

		public SerializationWritingEventArgs(SerializationWriterContext context, bool cancel) : base(context)
		{
			_cancel = cancel;
		}

		#endregion

		#region 公共属性

		public bool Cancel
		{
			get
			{
				return _cancel;
			}
			set
			{
				_cancel = value;
			}
		}

		#endregion
	}
}