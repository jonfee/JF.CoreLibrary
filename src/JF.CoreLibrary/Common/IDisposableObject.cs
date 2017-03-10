﻿using System;

namespace JF.Common
{
	public interface IDisposableObject : System.IDisposable
	{
		event EventHandler<DisposedEventArgs> Disposed;

		bool IsDisposed
		{
			get;
		}
	}

	public class DisposedEventArgs : EventArgs
	{
		#region 成员字段

		private bool _disposing;

		#endregion

		#region 构造方法

		public DisposedEventArgs(bool disposing)
		{
			_disposing = disposing;
		}

		#endregion

		#region 公共属性

		public bool Disposing
		{
			get
			{
				return _disposing;
			}
		}

		#endregion
	}
}