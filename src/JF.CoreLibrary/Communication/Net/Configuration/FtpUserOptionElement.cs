using System;
using System.Collections.Generic;
using JF.Options;
using JF.Options.Configuration;

namespace JF.Communication.Net.Configuration
{
	public class FtpUserOptionElement : OptionConfigurationElement
	{
		#region 常量定义

		private const string XML_USERNAME_ATTRIBUTE = "name";
		private const string XML_PASSWORD_ATTRIBUTE = "password";
		private const string XML_HOMEDIRECTORY_ATTRIBUTE = "homeDirectory";
		private const string XML_READONLY_ATTRIBUTE = "readOnly";

		#endregion

		#region 公共属性

		/// <summary>
		/// 获取或设置<see cref="FtpServer"/>服务器的登录用户名。
		/// </summary>
		[OptionConfigurationProperty(XML_USERNAME_ATTRIBUTE, Type = typeof(string), Behavior = OptionConfigurationPropertyBehavior.IsKey)]
		public string Name
		{
			get
			{
				return (string)this[XML_USERNAME_ATTRIBUTE];
			}
			set
			{
				this[XML_USERNAME_ATTRIBUTE] = value;
			}
		}

		/// <summary>
		/// 获取或设置<see cref="FtpServer"/>服务器的登录用户密码。
		/// </summary>
		[OptionConfigurationProperty(XML_PASSWORD_ATTRIBUTE, Type = typeof(string))]
		public string Password
		{
			get
			{
				return (string)this[XML_PASSWORD_ATTRIBUTE];
			}
			set
			{
				this[XML_PASSWORD_ATTRIBUTE] = value;
			}
		}

		/// <summary>
		/// 获取或设置<see cref="FtpServer"/>服务器的用户的主目录路径。
		/// </summary>
		[OptionConfigurationProperty(XML_HOMEDIRECTORY_ATTRIBUTE, Type = typeof(string))]
		public string HomeDirectory
		{
			get
			{
				return (string)this[XML_HOMEDIRECTORY_ATTRIBUTE];
			}
			set
			{
				this[XML_HOMEDIRECTORY_ATTRIBUTE] = value;
			}
		}

		/// <summary>
		/// 获取或设置<see cref="FtpServer"/>服务器的用户是否只读，默认为只读(true)。
		/// </summary>
		[OptionConfigurationProperty(XML_READONLY_ATTRIBUTE, Type = typeof(bool), DefaultValue = true)]
		public bool ReadOnly
		{
			get
			{
				return (bool)this[XML_READONLY_ATTRIBUTE];
			}
			set
			{
				this[XML_READONLY_ATTRIBUTE] = value;
			}
		}

		#endregion
	}
}