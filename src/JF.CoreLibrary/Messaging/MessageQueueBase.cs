using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace JF.Messaging
{
	public abstract class MessageQueueBase : IMessageQueue
	{
		#region 事件定义

		public event EventHandler<JF.Collections.DequeuedEventArgs> Dequeued;

		public event EventHandler<JF.Collections.EnqueuedEventArgs> Enqueued;

		#endregion

		#region 成员字段

		private string _name;

		#endregion

		#region 构造方法

		protected MessageQueueBase(string name)
		{
			if(string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("name");
			}

			_name = name.Trim();
		}

		#endregion

		#region 公共属性

		public virtual string Name
		{
			get
			{
				return _name;
			}
		}

		public virtual long Count
		{
			get
			{
				return TaskUtility.ExecuteTask(() => this.GetCountAsync());
			}
		}

		#endregion

		#region 保护属性

		protected virtual int Capacity
		{
			get
			{
				return 0;
			}
		}

		#endregion

		#region 公共方法

		public abstract Task<long> GetCountAsync();

		public virtual void Enqueue(object item, MessageEnqueueSettings settings = null)
		{
			this.EnqueueMany(new object[]
			{
				item
			}, settings);
		}

		public virtual int EnqueueMany<T>(IEnumerable<T> items, MessageEnqueueSettings settings = null)
		{
			return TaskUtility.ExecuteTask(() => this.EnqueueManyAsync(items, settings));
		}

		public virtual Task EnqueueAsync(object item, MessageEnqueueSettings settings = null)
		{
			return this.EnqueueManyAsync(new object[]
			{
				item
			}, settings);
		}

		public abstract Task<int> EnqueueManyAsync<TItem>(IEnumerable<TItem> items, MessageEnqueueSettings settings = null);

		public virtual MessageBase Dequeue(MessageDequeueSettings settings = null)
		{
			var result = this.Dequeue(1, settings);

			if(result == null)
			{
				return null;
			}

			return result.FirstOrDefault();
		}

		public virtual IEnumerable<MessageBase> Dequeue(int count, MessageDequeueSettings settings = null)
		{
			return TaskUtility.ExecuteTask(() => this.DequeueAsync(count));
		}

		public virtual async Task<MessageBase> DequeueAsync(MessageDequeueSettings settings = null)
		{
			var result = await this.DequeueAsync(1, settings);

			if(result == null)
			{
				return null;
			}

			return result.FirstOrDefault();
		}

		public abstract Task<IEnumerable<MessageBase>> DequeueAsync(int count, MessageDequeueSettings settings = null);

		public virtual MessageBase Peek()
		{
			var result = this.Peek(1);

			if(result == null)
			{
				return null;
			}
			else
			{
				return result.FirstOrDefault();
			}
		}

		public virtual IEnumerable<MessageBase> Peek(int count)
		{
			return TaskUtility.ExecuteTask(() => this.PeekAsync(count));
		}

		public virtual async Task<MessageBase> PeekAsync()
		{
			var result = await this.PeekAsync(1);

			if(result == null)
			{
				return null;
			}

			return result.FirstOrDefault();
		}

		public abstract Task<IEnumerable<MessageBase>> PeekAsync(int count);

		#endregion

		#region 队列实现

		void JF.Collections.IQueue.Clear()
		{
			this.ClearQueue();
		}

		void JF.Collections.IQueue.Enqueue(object item, object settings)
		{
			this.Enqueue(item, settings as MessageEnqueueSettings);
		}

		int JF.Collections.IQueue.EnqueueMany<T>(IEnumerable<T> items, object settings)
		{
			return this.EnqueueMany(items, settings as MessageEnqueueSettings);
		}

		Task JF.Collections.IQueue<MessageBase>.EnqueueAsync(object item, object settings)
		{
			return this.EnqueueAsync(item, settings as MessageEnqueueSettings);
		}

		Task<int> JF.Collections.IQueue<MessageBase>.EnqueueManyAsync<TItem>(IEnumerable<TItem> items, object settings)
		{
			return this.EnqueueManyAsync(items, settings as MessageEnqueueSettings);
		}

		object JF.Collections.IQueue.Dequeue()
		{
			return this.Dequeue(null);
		}

		IEnumerable JF.Collections.IQueue.Dequeue(int count)
		{
			return this.Dequeue(count, null);
		}

		MessageBase JF.Collections.IQueue<MessageBase>.Dequeue(object settings)
		{
			return this.Dequeue(settings as MessageDequeueSettings);
		}

		IEnumerable<MessageBase> JF.Collections.IQueue<MessageBase>.Dequeue(int count, object settings)
		{
			return this.Dequeue(count, settings as MessageDequeueSettings);
		}

		Task<MessageBase> JF.Collections.IQueue<MessageBase>.DequeueAsync(object settings)
		{
			return this.DequeueAsync(settings as MessageDequeueSettings);
		}

		Task<IEnumerable<MessageBase>> JF.Collections.IQueue<MessageBase>.DequeueAsync(int count, object settings)
		{
			return this.DequeueAsync(count, settings as MessageDequeueSettings);
		}

		object JF.Collections.IQueue.Peek()
		{
			return this.Peek();
		}

		IEnumerable JF.Collections.IQueue.Peek(int count)
		{
			return this.Peek(count);
		}

		object JF.Collections.IQueue.Take(int startOffset)
		{
			return this.TakeQueue(startOffset);
		}

		IEnumerable JF.Collections.IQueue.Take(int startOffset, int count)
		{
			return this.TakeQueue(startOffset, count);
		}

		MessageBase JF.Collections.IQueue<MessageBase>.Take(int startOffset)
		{
			return this.TakeQueue(startOffset);
		}

		IEnumerable<MessageBase> JF.Collections.IQueue<MessageBase>.Take(int startOffset, int count)
		{
			return this.TakeQueue(startOffset, count);
		}

		Task<MessageBase> JF.Collections.IQueue<MessageBase>.TakeAsync(int startOffset)
		{
			return this.TakeQueueAsync(startOffset);
		}

		Task<IEnumerable<MessageBase>> JF.Collections.IQueue<MessageBase>.TakeAsync(int startOffset, int count)
		{
			return this.TakeQueueAsync(startOffset, count);
		}

		#endregion

		#region 保护方法

		protected virtual void ClearQueue()
		{
			throw new NotSupportedException("The message queue does not support the operation.");
		}

		protected virtual void CopyQueueTo(Array array, int index)
		{
			throw new NotSupportedException("The message queue does not support the operation.");
		}

		protected virtual MessageBase TakeQueue(int startOffset)
		{
			var result = this.TakeQueue(startOffset, 1);

			if(result == null)
			{
				return null;
			}

			return result.GetEnumerator().Current;
		}

		protected virtual IEnumerable<MessageBase> TakeQueue(int startOffset, int count)
		{
			throw new NotSupportedException("The message queue does not support the operation.");
		}

		protected virtual async Task<MessageBase> TakeQueueAsync(int startOffset)
		{
			var result = await this.TakeQueueAsync(startOffset, 1);

			if(result == null)
			{
				return null;
			}

			return result.GetEnumerator().Current;
		}

		protected virtual Task<IEnumerable<MessageBase>> TakeQueueAsync(int startOffset, int count)
		{
			throw new NotSupportedException("The message queue does not support the operation.");
		}

		#endregion

		#region 激发事件

		protected virtual void OnDequeued(JF.Collections.DequeuedEventArgs args)
		{
			var handler = this.Dequeued;

			if(handler != null)
			{
				handler(this, args);
			}
		}

		protected virtual void OnEnqueued(JF.Collections.EnqueuedEventArgs args)
		{
			var handler = this.Enqueued;

			if(handler != null)
			{
				handler(this, args);
			}
		}

		#endregion

		#region 显式实现

		int JF.Collections.IQueue.Capacity
		{
			get
			{
				return this.Capacity;
			}
		}

		int ICollection.Count
		{
			get
			{
				return (int)this.Count;
			}
		}

		bool ICollection.IsSynchronized
		{
			get
			{
				return false;
			}
		}

		object ICollection.SyncRoot
		{
			get
			{
				throw new NotSupportedException("The message queue does not support the operation.");
			}
		}

		void ICollection.CopyTo(Array array, int index)
		{
			this.CopyQueueTo(array, index);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotSupportedException("The message queue does not support the operation.");
		}

		#endregion
	}
}