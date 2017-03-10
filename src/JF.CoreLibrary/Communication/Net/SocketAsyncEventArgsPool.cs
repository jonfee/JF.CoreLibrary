using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Threading;
using System.Text;

namespace JF.Communication.Net
{
	internal class SocketAsyncEventArgsPool : JF.Collections.ObjectPool<SocketAsyncEventArgs>
	{
		#region 成员字段

		private Action<object, SocketAsyncEventArgs> _completedCallback;

		#endregion

		#region 构造方法

		internal SocketAsyncEventArgsPool(Action<object, SocketAsyncEventArgs> completed) : base(100)
		{
			if(completed == null)
			{
				throw new ArgumentNullException("completed");
			}

			_completedCallback = completed;
		}

		#endregion

		#region 重写方法

		protected override SocketAsyncEventArgs OnCreate()
		{
			return new SocketAsyncEventArgs()
			{
				SocketFlags = SocketFlags.Partial,
			};
		}

		protected override void OnTakeout(SocketAsyncEventArgs value)
		{
			value.Completed += AsyncArgs_Completed;
		}

		protected override void OnTakein(SocketAsyncEventArgs value)
		{
			value.AcceptSocket = null;
			value.UserToken = null;
			value.SetBuffer(null, 0, 0);

			value.Completed -= AsyncArgs_Completed;
		}

		protected override void OnRemove(SocketAsyncEventArgs value)
		{
			value.Completed -= AsyncArgs_Completed;
			value.Dispose();
		}

		#endregion

		#region 私有方法

		private void AsyncArgs_Completed(object sender, SocketAsyncEventArgs args)
		{
			if(_completedCallback != null)
			{
				_completedCallback(sender, args);
			}
		}

		#endregion
	}
}