using System;
using System.Collections.Generic;

namespace JF.Push
{
	/// <summary>
	/// 表示用于描述推送客户端的类型。
	/// </summary>
	[Serializable]
	public class PushClient
	{
		#region 成员字段

		private string _appCode;

		private PushClientPlatform _devicePlatform;
		private string _deviceCode;

		#endregion

		#region 公共属性

		/// <summary>
		/// 获取或设置应用编号。
		/// </summary>
		public string AppCode
		{
			get
			{
				return _appCode;
			}
			set
			{
				if(string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException();

				_appCode = value;
			}
		}

		/// <summary>
		/// 获取或设置设备编号。（此值与设备及应用都相关，即不同的apk/ipa安装到同一台设备上的值都不相同）
		/// </summary>
		public string DeviceCode
		{
			get
			{
				return _deviceCode;
			}
			set
			{
				if(string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException();

				_deviceCode = value;
			}
		}

		/// <summary>
		/// 获取或设置设备所使用的操作系统。
		/// </summary>
		public PushClientPlatform DevicePlatform
		{
			get
			{
				return _devicePlatform;
			}
			set
			{
				_devicePlatform = value;
			}
		}

		#endregion

		#region 构造方法

		/// <summary>
		/// 初始化 <see cref="PushClient"/> 类的新实例。
		/// </summary>
		/// <param name="appCode">应用编号。</param>
		/// <param name="devicePlatform">设备操作系统。</param>
		/// <param name="deviceCode">设备编号。</param>
		public PushClient(string appCode, PushClientPlatform devicePlatform, string deviceCode)
		{
			if(string.IsNullOrWhiteSpace(appCode))
				throw new ArgumentNullException(nameof(appCode));

			if(string.IsNullOrWhiteSpace(deviceCode))
				throw new ArgumentNullException(nameof(deviceCode));

			this._appCode = appCode;
			this._devicePlatform = devicePlatform;
			this._deviceCode = deviceCode;
		}

		#endregion
	}
}