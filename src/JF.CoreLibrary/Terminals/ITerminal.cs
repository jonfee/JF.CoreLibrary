using System;
using System.IO;

namespace JF.Terminals
{
	public interface ITerminal : JF.Services.ICommandOutlet
	{
		#region 属性定义

		JF.Services.CommandOutletColor BackgroundColor
		{
			get;
			set;
		}

		JF.Services.CommandOutletColor ForegroundColor
		{
			get;
			set;
		}

		TextReader Input
		{
			get;
			set;
		}

		TextWriter Output
		{
			get;
			set;
		}

		TextWriter Error
		{
			get;
			set;
		}

		#endregion

		#region 方法定义

		void Clear();

		void Reset();

		void ResetStyles(TerminalStyles styles);

		#endregion
	}
}