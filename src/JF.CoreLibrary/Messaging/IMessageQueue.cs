using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JF.Messaging
{
	/// <summary>
	/// 表示消息队列的接口。
	/// </summary>
	public interface IMessageQueue : JF.Collections.IQueue<MessageBase>
	{
		#region 入队方法

		void Enqueue(object item, MessageEnqueueSettings settings = null);

		Task EnqueueAsync(object item, MessageEnqueueSettings settings = null);

		int EnqueueMany<TItem>(IEnumerable<TItem> items, MessageEnqueueSettings settings = null);

		Task<int> EnqueueManyAsync<TItem>(IEnumerable<TItem> items, MessageEnqueueSettings settings = null);

		#endregion

		#region 出队方法

		MessageBase Dequeue(MessageDequeueSettings settings = null);

		IEnumerable<MessageBase> Dequeue(int count, MessageDequeueSettings settings = null);

		Task<MessageBase> DequeueAsync(MessageDequeueSettings settings = null);

		Task<IEnumerable<MessageBase>> DequeueAsync(int count, MessageDequeueSettings settings = null);

		#endregion
	}
}