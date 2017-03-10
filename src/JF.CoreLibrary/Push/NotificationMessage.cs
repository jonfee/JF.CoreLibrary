using System;
using System.Collections.Generic;

using JF.ComponentModel;

namespace JF.Push
{
	/// <summary>
	/// 表示一条通知消息。
	/// 在通知栏显示一条含图标、标题等的通知，当用户点击后激活应用。
	/// </summary>
	[Serializable]
	public class NotificationMessage : PushMessage
	{
		#region 成员字段

		private string _title;
		private string _text;

		private AndroidSettings _android = new AndroidSettings();
		private IOSSettings _ios = new IOSSettings();

		#endregion

		#region 公共属性

		/// <summary>
		/// 获取或设置通知标题。
		/// 当标题为空时，默认显示当前应用的应用名称。
		/// </summary>
		public string Title
		{
			get
			{
				return _title;
			}
			set
			{
				if(!string.IsNullOrWhiteSpace(value))
				{
					// 通知标题不能超过40个字符。
					if(value.Length > 40)
						throw new ArgumentOutOfRangeException();
				}

				this._title = value;
			}
		}

		/// <summary>
		/// 获取或设置通知内容。
		/// </summary>
		public string Text
		{
			get
			{
				return _text;
			}
			set
			{
				if(string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException();

				// 通知内容不能超过600个字符。
				if(value.Length > 600)
					throw new ArgumentOutOfRangeException();

				this._text = value;
			}
		}

		/// <summary>
		/// 获取或设置针对 Android 设备的配置项。
		/// </summary>
		public AndroidSettings Android
		{
			get
			{
				return _android;
			}
			set
			{
				if(value == null)
					throw new ArgumentNullException();

				this._android = value;
			}
		}

		/// <summary>
		/// 获取或设置针对 IOS 设备的配置项。
		/// </summary>
		public IOSSettings IOS
		{
			get
			{
				return _ios;
			}
			set
			{
				if(value == null)
					throw new ArgumentNullException();

				this._ios = value;
			}
		}

		#endregion

		#region 构造方法

		/// <summary>
		/// 初始化 <see cref="NotificationMessage"/> 类的新实例。
		/// </summary>
		/// <param name="text">通知内容。</param>
		/// <param name="title">通知标题。</param>
		public NotificationMessage(string text, string title = null) : base(PushMessageType.Notification)
		{
			if(string.IsNullOrWhiteSpace(text))
				throw new ArgumentNullException(nameof(text));

			this.Text = text;
			this.Title = title;
		}

		#endregion

		#region 嵌套子类

		/// <summary>
		/// 针对 Android 设备的通知配置。
		/// </summary>
		public class AndroidSettings
		{
			#region 成员字段

			/*
			private bool _isRing;
			private bool _isVibrate;
			private bool _isClearable;
			*/

			private bool _isTrans;
			private bool _isOpenApp;
			private int _offlineExpireTime;

			#endregion

			#region 公共属性

			/*
			/// <summary>
			/// 收到通知是否响铃。（默认响铃）
			/// </summary>
			public bool IsRing
			{
				get
				{
					return _isRing;
				}
				set
				{
					_isRing = value;
				}
			}

			/// <summary>
			/// 收到通知是否震动。（默认震动）
			/// </summary>
			public bool IsVibrate
			{
				get
				{
					return _isVibrate;
				}
				set
				{
					_isVibrate = value;
				}
			}

			/// <summary>
			/// 收到通知是否可清除。
			/// </summary>
			public bool IsClearable
			{
				get
				{
					return _isClearable;
				}
				set
				{
					_isClearable = value;
				}
			}
			*/

			/// <summary>
			/// 获取或设置发送通知时，是否同时发送透传。
			/// </summary>
			public bool IsTrans
			{
				get
				{
					return _isTrans;
				}
				set
				{
					_isTrans = value;
				}
			}

			/// <summary>
			/// 获取或设置当客户端收到通知时，是否立即打开App。
			/// </summary>
			public bool IsOpenApp
			{
				get
				{
					return _isOpenApp;
				}
				set
				{
					_isOpenApp = value;
				}
			}

			/// <summary>
			/// 获取或设置当客户端不在线时，离线存储的有效时长。(单位：小时， 范围：0-72 小时内的正整数)
			/// </summary>
			public int OfflineExpireTime
			{
				get
				{
					return _offlineExpireTime;
				}
				set
				{
					// 离线时长不能超过72小时。
					if(value < 0 || value > 72)
						throw new ArgumentOutOfRangeException();

					_offlineExpireTime = value;
				}
			}

			#endregion

			#region 构造方法

			/// <summary>
			/// 初始化 <see cref="AndroidSettings"/> 类的新实例。
			/// </summary>
			public AndroidSettings()
			{
//				this._isRing = true;
//				this._isVibrate = true;
//				this._isClearable = true;
				this._isTrans = true;
				this._isOpenApp = true;
				this._offlineExpireTime = 24;
			}

			#endregion
		}

		/// <summary>
		/// 针对 IOS 设备的通知配置。
		/// </summary>
		public class IOSSettings
		{
			#region 成员字段

			private int _badge;
			private string _category;
			private string _sound;

			#endregion

			#region 公共属性

			/// <summary>
			/// 获取或设置设置应用右上角数字，用于提醒用户未阅读消息数量。
			/// </summary>
			public int Badge
			{
				get
				{
					return _badge;
				}
				set
				{
					_badge = value;
				}
			}

			/// <summary>
			/// 获取或设置自定义通知按钮事件。（支持 iOS 8.0及以上版本）
			/// </summary>
			public string Category
			{
				get
				{
					return _category;
				}
				set
				{
					_category = value;
				}
			}

			/// <summary>
			/// 当 Sound 为无时，用户收到消息将没有任何声音；
			/// 当 Sound 为默认时，用户将收到系统默认声音；
			/// 当 Sound 为自定义时，需在APP中配置该声音，如未配置，用户将收到系统默认声音。
			/// </summary>
			public string Sound
			{
				get
				{
					return _sound;
				}
				set
				{
					_sound = value;
				}
			}

			#endregion

			#region 构造方法

			/// <summary>
			/// 初始化 <see cref="IOSSettings"/> 类的新实例。
			/// </summary>
			public IOSSettings()
			{
				this._badge = -1;
				this._sound = "default";
			}

			#endregion
		}

		#endregion
	}
}
