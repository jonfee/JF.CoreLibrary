using System;
using System.Collections.Generic;
using JF.ComponentModel;

namespace JF.Push
{
	/// <summary>
	/// 表示推送消息的类型。
	/// </summary>
	public enum PushMessageType
	{
		/// <summary>
		/// 通知消息。（Android 与 IOS 都适用）
		/// 在通知栏显示一条含图标、标题等的通知，当用户点击后激活应用。
		/// </summary>
		[Alias("notify")]
		Notification = 1,

		/// <summary>
		/// 透传消息。（Android 与 IOS 都适用）
		/// 仅当客户端在线时，数据经SDK传给客户端，由客户端决定如何处理展现给用户。
		/// </summary>
		[Alias("trans")]
		Transmission = 2,

		/// <summary>
		/// 点击通知打开网页。（仅 Android 适用）
		/// 在通知栏显示一条含图标、标题等的通知，用户点击可打开指定的网页。
		/// </summary>
		[Alias("link")]
		Link = 4,

		/// <summary>
		/// 通知栏弹框下载。（仅 Android 适用）
		/// 在通知栏显示一条含图标、标题等的通知，用户点击后弹出框，用户可以选择直接下载应用或者取消下载应用。
		/// </summary>
		[Alias("down")]
		Download = 8
	}
}