using System;
using System.Collections.Generic;

namespace JF.SMS
{
	/// <summary>
	/// 表示消息模板。
	/// </summary>
	[Serializable]
	public class MessageTemplate
	{
		#region 成员字段

		private string _identifier;
		private Dictionary<string, string> _parameters;

		#endregion

		#region 成员属性

		/// <summary>
		/// 获取或设置模板标识符。
		/// </summary>
		public string Identifier
		{
			get
			{
				return _identifier;
			}
			set
			{
				if(string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException();

				_identifier = value;
			}
		}

		/// <summary>
		/// 获取或设置模板参数。
		/// </summary>
		public Dictionary<string, string> Parameters
		{
			get
			{
				return _parameters;
			}
			set
			{
				if(value == null)
					throw new ArgumentNullException();

				_parameters = value;
			}
		}

		#endregion

		#region 构造方法

		/// <summary>
		/// 初始化 <see cref="MessageTemplate"/> 类的新实例。
		/// </summary>
		/// <param name="identifier">模板标识符，可以为编号或名称。</param>
		public MessageTemplate(string identifier) : this(identifier, new Dictionary<string, string>())
		{

		}

		/// <summary>
		/// 初始化 <see cref="MessageTemplate"/> 类的新实例。
		/// </summary>
		/// <param name="identifier">模板标识符，可以为编号或名称。</param>
		/// <param name="parameters">模板参数。</param>
		public MessageTemplate(string identifier, Dictionary<string, string> parameters)
		{
			if(string.IsNullOrWhiteSpace(identifier))
				throw new ArgumentNullException(nameof(identifier));

			this._identifier = identifier;
			this._parameters = parameters;
		}

		#endregion
	}
}
