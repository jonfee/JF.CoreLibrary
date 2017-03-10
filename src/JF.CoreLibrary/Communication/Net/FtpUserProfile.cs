using System;
using System.Collections.Generic;

namespace JF.Communication.Net
{
	public class FtpUserProfile
	{
		/// <summary>
		/// 每个IP的最大连接数
		/// </summary>
		public int ConnectionLimitPerIP
		{
			get;
			set;
		}

		/// <summary>
		/// 限制上传的最大文件长度
		/// (超过这个值，数据连接会被关闭,传输失败)
		/// </summary>
		public long MaxUploadFileLength
		{
			get;
			set;
		}

		/// <summary>
		/// 使用该帐号的连接最大连接数
		/// </summary>
		public int MaxConnectionCount
		{
			get;
			set;
		}

		/// <summary>
		/// 用户使用的本地目录(绝对路径)
		/// </summary>
		public string HomeDir
		{
			get;
			set;
		}

		/// <summary>
		/// 是否允许读(包括主要是FTP的List和Download操作)
		/// </summary>
		public bool AllowRead
		{
			get;
			set;
		}

		/// <summary>
		/// 是否允许写（主要涉及FTP中的Delete，Upload和Create操作)
		/// </summary>
		public bool AllowWrite
		{
			get;
			set;
		}

		/// <summary>
		/// 用户名称
		/// </summary>
		public string UserName
		{
			get;
			set;
		}

		/// <summary>
		/// 用户密码
		/// </summary>
		public string Password
		{
			get;
			set;
		}
	}
}