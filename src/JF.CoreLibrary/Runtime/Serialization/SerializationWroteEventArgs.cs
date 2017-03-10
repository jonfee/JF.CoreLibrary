using System;
using System.Collections.Generic;

namespace JF.Runtime.Serialization
{
	public class SerializationWroteEventArgs : EventArgs
	{
		#region 成员字段

		private SerializationWriterContext _context;

		#endregion

		#region 构造方法

		public SerializationWroteEventArgs(SerializationWriterContext context)
		{
			if(context == null)
			{
				throw new ArgumentNullException("context");
			}

			_context = context;
		}

		#endregion

		#region 公共属性

		public SerializationWriterContext Context
		{
			get
			{
				return _context;
			}
		}

		#endregion
	}
}