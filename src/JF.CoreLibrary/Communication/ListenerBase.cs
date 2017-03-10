using System;
using System.Net;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using JF.Services;
using JF.Services.Composition;

namespace JF.Communication
{
	/// <summary>
	/// 提供通讯侦听功能的抽象基类。
	/// </summary>
	public abstract class ListenerBase : WorkerBase, IListener, IReceiver
	{
		#region 事件定义

		public event EventHandler<ChannelFailureEventArgs> Failed;

		public event EventHandler<ReceivedEventArgs> Received;

		#endregion

		#region 私有变量

		private readonly object _syncRoot;

		#endregion

		#region 成员字段

		private IReceiver _receiver;
		private IExecutor _executor;

		#endregion

		#region 构造方法

		protected ListenerBase(string name) : base(name)
		{
			_syncRoot = new object();
		}

		#endregion

		#region 公共属性

		public virtual bool IsListening
		{
			get
			{
				return this.State == WorkerState.Running;
			}
		}

		public IReceiver Receiver
		{
			get
			{
				if(_receiver == null)
				{
					lock(_syncRoot)
					{
						if(_receiver == null)
						{
							_receiver = this.CreateReceiver();

							//绑定接收器的事件
							this.BindReceiver(_receiver, null);
						}
					}
				}

				return _receiver;
			}
			protected set
			{
				//绑定接收器事件(先取消原有接收器的事件，再挂载新接收器事件)
				this.BindReceiver(value, _receiver);

				_receiver = value;
			}
		}

		public IExecutor Executor
		{
			get
			{
				if(_executor == null)
				{
					System.Threading.Interlocked.CompareExchange(ref _executor, this.CreateExecutor(), null);
				}

				return _executor;
			}
			set
			{
				if(object.ReferenceEquals(_executor, value))
				{
					return;
				}

				//设置属性的成员字段
				_executor = value;
			}
		}

		#endregion

		#region 虚拟方法

		protected virtual IReceiver CreateReceiver()
		{
			return this;
		}

		protected virtual IExecutor CreateExecutor()
		{
			return new Utility.CommunicationExecutor(this);
		}

		protected virtual void OnFailed(ChannelFailureEventArgs args)
		{
			var handler = this.Failed;

			if(handler != null)
			{
				handler(this, args);
			}
		}

		protected virtual void OnReceived(ReceivedEventArgs args)
		{
			//处理接收到的数据
			Utility.ProcessReceive(_executor, args);

			var handler = this.Received;

			if(handler != null)
			{
				handler(this, args);
			}
		}

		#endregion

		#region 释放资源

		protected override void Dispose(bool disposing)
		{
			//必须确保内部引用的接收器不为当前侦听器本身
			if(!object.ReferenceEquals(_receiver, this))
			{
				if(_receiver != null)
				{
					_receiver.Failed -= new EventHandler<ChannelFailureEventArgs>(Receiver_Failed);
					_receiver.Received -= new EventHandler<ReceivedEventArgs>(Receiver_Received);
				}

				IDisposable disposable = _receiver as IDisposable;

				if(disposable != null)
				{
					disposable.Dispose();
				}
			}

			//调用基类同名方法
			base.Dispose(disposing);
		}

		#endregion

		#region 私有方法

		private void BindReceiver(IReceiver newReceiver, IReceiver oldReceiver)
		{
			if(object.ReferenceEquals(newReceiver, oldReceiver))
			{
				return;
			}

			if(oldReceiver != null && (!object.ReferenceEquals(oldReceiver, this)))
			{
				oldReceiver.Failed -= new EventHandler<ChannelFailureEventArgs>(Receiver_Failed);
				oldReceiver.Received -= new EventHandler<ReceivedEventArgs>(Receiver_Received);
			}

			if(newReceiver != null && !object.ReferenceEquals(newReceiver, this))
			{
				newReceiver.Failed += new EventHandler<ChannelFailureEventArgs>(Receiver_Failed);
				newReceiver.Received += new EventHandler<ReceivedEventArgs>(Receiver_Received);
			}
		}

		private void Receiver_Failed(object sender, ChannelFailureEventArgs e)
		{
			this.OnFailed(e);
		}

		private void Receiver_Received(object sender, ReceivedEventArgs e)
		{
			//激发“Received”事件
			this.OnReceived(e);
		}

		#endregion
	}
}