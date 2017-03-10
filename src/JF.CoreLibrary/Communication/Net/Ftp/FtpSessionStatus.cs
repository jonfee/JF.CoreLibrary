using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JF.Communication.Net.Ftp
{
	/// <summary>
	/// 会话状态
	/// </summary>
	internal enum FtpSessionStatus
	{
		/// <summary>
		/// 已经登陆，空闲状态
		/// </summary>
		Wait,

		/// <summary>
		/// 未登陆
		/// </summary>
		NotLogin,

		/// <summary>
		/// 正在执行List命令
		/// </summary>
		List,

		/// <summary>
		/// 正在上传文件
		/// </summary>
		Upload,

		/// <summary>
		/// 正在下载文件
		/// </summary>
		Download,
	}
}