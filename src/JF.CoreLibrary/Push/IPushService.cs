using System;
using System.Collections.Generic;

namespace JF.Push
{
	/// <summary>
	/// 表示实现该接口的是一个推送服务。
	/// </summary>
	public interface IPushService
	{
		/// <summary>
		/// 发布一条消息到指定的客户端。
		/// </summary>
		/// <param name="client">推送客户端。</param>
		/// <param name="message">推送消息。</param>
		/// <returns>推送任务实例。</returns>
		PushTask Publish(PushClient client, PushMessage message);

		/// <summary>
		/// 发布多条推送项至指定的客户端。
		/// </summary>
		/// <param name="entries">推送项集合。</param>
		/// <returns>推送任务集合。</returns>
		IEnumerable<PushTask> Publish(IEnumerable<PushEntry> entries);

		/// <summary>
		/// 取消一个推送任务。
		/// 对处于推送状态，或未接收的消息将停止下发；
		/// 而对于已发送的消息将标记为已取消。
		/// </summary>
		/// <param name="taskId">任务编号。</param>
		void Cancel(Guid taskId);

		/// <summary>
		/// 取消多个推送任务。
		/// 对处于推送状态，或未接收的消息将停止下发；
		/// 而对于已发送的消息将标记为已取消。
		/// </summary>
		void Cancel(IEnumerable<Guid> taskIds);

		/// <summary>
		/// 接收一个推送任务。
		/// </summary>
		/// <remarks>客户端收到推送时，应主动向服务器报告消息已接收。</remarks>
		/// <param name="taskId">任务编号。</param>
		void Receive(Guid taskId);

		/// <summary>
		/// 接收多个推送任务。
		/// </summary>
		/// <remarks>客户端收到推送时，应主动向服务器报告消息已接收。</remarks>
		/// <param name="taskIds">任务编号集合。</param>
		void Receive(IEnumerable<Guid> taskIds);

		/// <summary>
		/// 根据指定编号获取推送任务实例。
		/// </summary>
		/// <param name="taskId">任务编号。</param>
		/// <returns>推送任务实例。</returns>
		PushTask GetTask(Guid taskId);

		/// <summary>
		/// 根据指定编号集合获取推送任务集合。
		/// </summary>
		/// <param name="taskIds">任务编号集合。</param>
		/// <returns>推送任务集合。</returns>
		IEnumerable<PushTask> GetTasks(IEnumerable<Guid> taskIds);

		/// <summary>
		/// 获取指定客户端所有推送任务集合。
		/// </summary>
		/// <param name="client">客户端实例。</param>
		/// <returns>推送任务集合。</returns>
		IEnumerable<PushTask> GetTasks(PushClient client);

		/// <summary>
		/// 获取指定客户端未收到的推送任务集合。
		/// </summary>
		/// <param name="client">客户端实例。</param>
		/// <returns>推送任务集合。</returns>
		IEnumerable<PushTask> GetUnreceivedTasks(PushClient client);

		/// <summary>
		/// 获取指定客户端的状态。
		/// </summary>
		/// <param name="client">指定的客户端。</param>
		/// <returns>客户端状态。</returns>
		PushClientStatus GetClientStatus(PushClient client);

		/// <summary>
		/// 获取指定客户端的别名。
		/// </summary>
		/// <param name="client">指定的客户端。</param>
		/// <returns>客户端别名。</returns>
		string GetAlias(PushClient client);

		/// <summary>
		/// 将指定客户端与指定别名进行绑定。
		/// </summary>
		/// <param name="client">指定的客户端。</param>
		/// <param name="alias">别名字符串实例。</param>
		void BindAlias(PushClient client, string alias);

		/// <summary>
		/// 将指定客户端与指定别名进行解绑。
		/// </summary>
		/// <param name="client">指定的客户端。</param>
		/// <param name="alias">别名字符串实例。</param>
		void UnBindAlias(PushClient client, string alias);
	}
}
