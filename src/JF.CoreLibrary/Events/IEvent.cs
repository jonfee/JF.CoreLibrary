using System;

namespace JF.Events
{
	/// <summary>
	/// 表示实现该接口的类型为事件类型。
	/// </summary>
	public interface IEvent
	{
		#region 公共属性

		/// <summary>
		/// 获取事件的唯一标识符。
		/// </summary>
		Guid ID
		{
			get;
		}

		/// <summary>
		/// 获取产生事件的事件源对象。
		/// </summary>
		object Source
		{
			get;
		}

		/// <summary>
		/// 获取产生事件的时间戳。
		/// </summary>
		/// <remarks>
		/// 为了支持事件产生时间的一致性，通常事件时间戳都是以 UTC 的方式进行表述。
		/// 对于应用系统本身而言，可以根据具体需求将 UTC 时间转换为本地时间。
		/// </remarks>
		DateTime TimeStamp
		{
			get;
		}

		#endregion
	}
}
