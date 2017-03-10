using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace JF.ComponentModel
{
	/// <summary>
	/// 表示提供进度通知的接口。
	/// </summary>
	public interface INotifyProgressChanged
	{
		/// <summary>
		/// 进度发生改变后的通知事件。
		/// </summary>
		event ProgressChangedEventHandler ProgressChanged;
	}
}