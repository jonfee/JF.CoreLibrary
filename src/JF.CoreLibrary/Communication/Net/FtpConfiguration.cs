using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JF.Communication.Net
{
	public class FtpConfiguration
	{
		public FtpConfiguration()
		{
			Port = 21;
			DefaultEncoding = Encoding.ASCII;
			WelcomeMessage = "JF.FTP Server V1.0 ready.";
			ExitMessage = "Bye.";
			DataOperationTimeout = TimeSpan.FromMinutes(2);
			AllowAnonymous = false;
			Users = new Dictionary<string, FtpUserProfile>();
		}

		/// <summary>
		/// Ftp服务端口
		/// </summary>
		public int Port
		{
			get;
			set;
		}

		/// <summary>
		/// 字符编码
		/// </summary>
		public Encoding DefaultEncoding
		{
			get;
			set;
		}

		/// <summary>
		/// 欢迎信息
		/// </summary>
		public string WelcomeMessage
		{
			get;
			set;
		}

		/// <summary>
		/// 退出信息
		/// </summary>
		public string ExitMessage
		{
			get;
			set;
		}

		/// <summary>
		/// 允许匿名用户
		/// </summary>
		public bool AllowAnonymous
		{
			get;
			set;
		}

		/// <summary>
		/// 用户集合
		/// </summary>
		public IDictionary<string, FtpUserProfile> Users
		{
			get;
			set;
		}

		/// <summary>
		/// 匿名用户信息
		/// </summary>
		public FtpUserProfile AnonymousUser
		{
			get;
			set;
		}

		/// <summary>
		/// 操作超时时间
		/// </summary>
		public TimeSpan DataOperationTimeout
		{
			get;
			set;
		}
	}
}