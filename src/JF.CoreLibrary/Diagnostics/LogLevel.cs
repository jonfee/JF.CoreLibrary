﻿using System;
using System.ComponentModel;

namespace JF.Diagnostics
{
	/// <summary>
	/// 表示日志的级别。
	/// </summary>
	public enum LogLevel
	{
		/// <summary>跟踪(1)</summary>
		Trace = 1,

		/// <summary>调试(2)</summary>
		Debug,

		/// <summary>信息(3)</summary>
		Info,

		/// <summary>警告(4)</summary>
		Warn,

		/// <summary>错误(5)</summary>
		Error,

		/// <summary>崩溃(6)</summary>
		Fatal,
	}
}