using System;
using System.ComponentModel;

namespace JF.Communication.Net.Ftp
{
	/// <summary>
	/// 表示传输方式的枚举。
	/// </summary>
	internal enum FtpTransferMode
	{
		/// <summary>
		/// ASCII 文本传输模式。
		/// </summary>
		Ascii = 0,

		/// <summary>
		/// 二进制传输模式。
		/// </summary>
		Binary = 1,
	}
}