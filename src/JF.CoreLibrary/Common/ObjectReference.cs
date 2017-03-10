using System;

namespace JF.Common
{
	public class ObjectReference<T> : MarshalByRefObject, IDisposableObject, IObjectReference<T> where T : class
	{
		#region 事件定义

		public event EventHandler<DisposedEventArgs> Disposed;

		#endregion

		#region 常量定义

		private const int NORMAL_STATE = 0;
		private const int DISPOSED_STATE = 1;

		#endregion

		#region 同步变量

		private readonly object _syncRoot;

		#endregion

		#region 成员字段

		private T _target;
		private int _state;
		private Func<T> _targetFactory;

		#endregion

		#region 构造方法

		public ObjectReference(Func<T> targetFactory)
		{
			if(targetFactory == null)
			{
				throw new ArgumentNullException("targetFactory");
			}

			_targetFactory = targetFactory;
			_syncRoot = new Object();
		}

		#endregion

		#region 公共属性

		public bool IsDisposed
		{
			get
			{
				return _state == DISPOSED_STATE;
			}
		}

		public virtual bool HasTarget
		{
			get
			{
				if(_state == NORMAL_STATE)
				{
					return _target != null;
				}

				return false;
			}
		}

		public virtual T Target
		{
			get
			{
				if(_state == DISPOSED_STATE)
				{
					throw new ObjectDisposedException(this.GetType().FullName);
				}

				if(_target == null)
				{
					lock(_syncRoot)
					{
						if(_target == null)
						{
							var target = _targetFactory();

							if(target != null)
							{
								if(target is IDisposableObject)
								{
									((IDisposableObject)target).Disposed += DisposableObject_Disposed;
								}

								_target = target;
								_state = NORMAL_STATE;
							}
						}
					}
				}

				return _target;
			}
		}

		#endregion

		#region 激发事件

		protected virtual void OnDisposed(DisposedEventArgs args)
		{
			var disposed = this.Disposed;

			if(disposed != null)
			{
				disposed(this, args);
			}
		}

		#endregion

		#region 私有方法

		private void DisposableObject_Disposed(object sender, DisposedEventArgs e)
		{
			_state = DISPOSED_STATE;
			_target = null;

			var target = sender as IDisposableObject;

			if(target != null)
			{
				target.Disposed -= DisposableObject_Disposed;
			}
		}

		#endregion

		#region 处置方法

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			var original = System.Threading.Interlocked.Exchange(ref _state, DISPOSED_STATE);

			if(original == DISPOSED_STATE)
			{
				return;
			}

			_state = DISPOSED_STATE;

			var disposable = _target as IDisposable;

			if(disposable != null)
			{
				disposable.Dispose();
			}

			_target = null;

			this.OnDisposed(new DisposedEventArgs(disposing));
		}

		#endregion
	}
}