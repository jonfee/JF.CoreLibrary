using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JF.Options;
using JF.Options.Configuration;

namespace JF.Communication.Net.Configuration
{
	public class FtpServerOptionElement : OptionConfigurationElement
	{
		#region 常量定义

		private const string XML_PORT_ATTRIBUTE = "port";
		private const string XML_ENCODING_ATTRIBUTE = "encoding";
		private const string XML_TIMEOUT_ATTRIBUTE = "timeout";
		private const string XML_USERS_COLLECTION = "users";

		#endregion

		#region 公共属性

		/// <summary>
		/// 获取或设置<see cref="FtpServer"/>服务器的侦听端口号，默认值为21。
		/// </summary>
		[OptionConfigurationProperty(XML_PORT_ATTRIBUTE, Type = typeof(int), DefaultValue = 21)]
		public int Port
		{
			get
			{
				return (int)this[XML_PORT_ATTRIBUTE];
			}
			set
			{
				this[XML_PORT_ATTRIBUTE] = value;
			}
		}

		/// <summary>
		/// 获取或设置<see cref="FtpServer"/>服务器的文本编码类型，默认值为Ascii编码。
		/// </summary>
		[OptionConfigurationProperty(XML_ENCODING_ATTRIBUTE, Type = typeof(Encoding), DefaultValue = "ASCII")]
		public Encoding Encoding
		{
			get
			{
				return (Encoding)this[XML_ENCODING_ATTRIBUTE];
			}
			set
			{
				this[XML_ENCODING_ATTRIBUTE] = value;
			}
		}

		/// <summary>
		/// 获取或设置<see cref="FtpServer"/>服务器的操作超时时长，单位为秒。默认值为60秒。
		/// </summary>
		[OptionConfigurationProperty(XML_TIMEOUT_ATTRIBUTE, Type = typeof(int), DefaultValue = 60)]
		public int Timeout
		{
			get
			{
				return (int)this[XML_TIMEOUT_ATTRIBUTE];
			}
			set
			{
				this[XML_TIMEOUT_ATTRIBUTE] = value;
			}
		}

		/// <summary>
		/// 获取<see cref="FtpServer"/>的登录用户集合。
		/// </summary>
		[OptionConfigurationProperty(XML_USERS_COLLECTION)]
		public FtpUserOptionElementCollection Users
		{
			get
			{
				return (FtpUserOptionElementCollection)this[XML_USERS_COLLECTION];
			}
		}

		#endregion
	}
}