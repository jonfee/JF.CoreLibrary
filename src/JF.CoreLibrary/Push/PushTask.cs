using System;
using System.Collections.Generic;

namespace JF.Push
{
	/// <summary>
	/// 表示一个推送任务。
	/// </summary>
	[Serializable]
	public class PushTask
	{
		#region 成员字段

		private Guid _taskId;

		private PushClient _client;
		private PushMessage _message;
		private PushTaskStatus _status;

		private string _summary;
		private string _associatedId;

		private DateTime _createdTime;
		private DateTime? _modifiedTime;

		#endregion

		#region 公共属性

		/// <summary>
		/// 获取或设置任务编号。
		/// </summary>
		public Guid TaskId
		{
			get
			{
				return _taskId;
			}
			set
			{
				_taskId = value;
			}
		}

		/// <summary>
		/// 获取或设置推送客户端。
		/// </summary>
		public PushClient Client
		{
			get
			{
				return _client;
			}
			set
			{
				if(value == null)
					throw new ArgumentNullException();

				_client = value;
			}
		}

		/// <summary>
		/// 获取或设置推送消息。
		/// </summary>
		public PushMessage Message
		{
			get
			{
				return _message;
			}
			set
			{
				if(value == null)
					throw new ArgumentNullException();

				_message = value;
			}
		}

		/// <summary>
		/// 获取或设置任务状态。
		/// </summary>
		public PushTaskStatus Status
		{
			get
			{
				return _status;
			}
			set
			{
				_status = value;
			}
		}

		/// <summary>
		/// 获取当前任务的描述信息。
		/// </summary>
		public string Summary
		{
			get
			{
				return _summary;
			}
			set
			{
				_summary = value;
			}
		}

		/// <summary>
		/// 获取或设置任务关联第三方推送平台的任务编号。
		/// </summary>
		public string AssociatedId
		{
			get
			{
				return _associatedId;
			}
			set
			{
				if(string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException();

				_associatedId = value;
			}
		}

		/// <summary>
		/// 获取或设置任务创建时间。
		/// </summary>
		public DateTime CreatedTime
		{
			get
			{
				return _createdTime;
			}
			set
			{
				_createdTime = value;
			}
		}

		/// <summary>
		/// 获取或设置任务最后修改时间。
		/// </summary>
		public DateTime? ModifiedTime
		{
			get
			{
				return _modifiedTime;
			}
			set
			{
				_modifiedTime = value;
			}
		}

		#endregion

		#region 构造方法

		/// <summary>
		/// 初始化 <see cref="PushTask"/> 类的新实例。
		/// </summary>
		public PushTask() : this(Guid.NewGuid())
		{

		}

		/// <summary>
		/// 初始化 <see cref="PushTask"/> 类的新实例。
		/// </summary>
		/// <param name="client">推送客户端。</param>
		/// <param name="message">推送消息。</param>
		public PushTask(PushClient client, PushMessage message) : this(Guid.NewGuid())
		{
			if(client == null)
				throw new ArgumentNullException(nameof(client));

			if(message == null)
				throw new ArgumentNullException(nameof(message));

			this._client = client;
			this._message = message;
		}

		/// <summary>
		/// 初始化 <see cref="PushTask"/> 类的新实例。
		/// </summary>
		/// <param name="taskId">任务ID。</param>
		public PushTask(Guid taskId)
		{
			this._taskId = taskId;
			this._status = PushTaskStatus.Submitting;
			this._createdTime = DateTime.Now;
		}

		#endregion
	}
}
