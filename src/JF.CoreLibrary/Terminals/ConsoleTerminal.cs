﻿using System;
using System.IO;
using System.Text;
using JF.Services;

namespace JF.Terminals
{
	public class ConsoleTerminal : MarshalByRefObject, ITerminal
	{
		#region 同步变量

		private readonly object _syncRoot;

		#endregion

		#region 成员字段

		private TerminalCommandExecutor _executor;

		#endregion

		#region 构造方法

		public ConsoleTerminal()
		{
			_syncRoot = new object();
		}

		public ConsoleTerminal(TerminalCommandExecutor executor)
		{
			if(executor == null)
			{
				throw new ArgumentNullException("executor");
			}

			_syncRoot = new object();
			_executor = executor;
		}

		#endregion

		#region 公共属性

		public TerminalCommandExecutor Executor
		{
			get
			{
				return _executor;
			}
		}

		public TextReader Input
		{
			get
			{
				return Console.In;
			}
			set
			{
				Console.SetIn(value);
			}
		}

		public TextWriter Output
		{
			get
			{
				return Console.Out;
			}
			set
			{
				Console.SetOut(value);
			}
		}

		public TextWriter Error
		{
			get
			{
				return Console.Error;
			}
			set
			{
				Console.SetError(value);
			}
		}

		public CommandOutletColor BackgroundColor
		{
			get
			{
				return this.ConvertColor(Console.BackgroundColor, CommandOutletColor.Black);
			}
			set
			{
				Console.BackgroundColor = ConvertColor(value, ConsoleColor.Black);
			}
		}

		public CommandOutletColor ForegroundColor
		{
			get
			{
				return this.ConvertColor(Console.ForegroundColor, CommandOutletColor.White);
			}
			set
			{
				Console.ForegroundColor = ConvertColor(value, ConsoleColor.White);
			}
		}

		#endregion

		#region 公共方法

		public void Clear()
		{
			Console.Clear();
		}

		public void Reset()
		{
			//恢复默认的颜色设置
			Console.ResetColor();

			try
			{
				if(Console.CursorLeft > 0)
				{
					Console.WriteLine();
				}
			}
			catch
			{
			}

			//先显示命令提示符
			if(_executor == null || _executor.Current == null || _executor.Current == _executor.Root)
			{
				Console.Write("#>");
			}
			else
			{
				Console.Write("{0}>", _executor.Current.FullPath);
			}
		}

		public void ResetStyles(TerminalStyles styles)
		{
			if((styles & TerminalStyles.Color) == TerminalStyles.Color)
			{
				Console.ResetColor();
			}
		}

		public void Write(string text)
		{
			Console.Write(text);
		}

		public void Write(object value)
		{
			Console.Write(value);
		}

		public void Write(CommandOutletColor foregroundColor, string text)
		{
			lock(_syncRoot)
			{
				var originalColor = this.ForegroundColor;
				this.ForegroundColor = foregroundColor;

				Console.Write(text);

				this.ForegroundColor = originalColor;
			}
		}

		public void Write(CommandOutletColor foregroundColor, object value)
		{
			lock(_syncRoot)
			{
				var originalColor = this.ForegroundColor;
				this.ForegroundColor = foregroundColor;

				Console.Write(value);

				this.ForegroundColor = originalColor;
			}
		}

		public void Write(string format, params object[] args)
		{
			Console.Write(format, args);
		}

		public void Write(CommandOutletColor foregroundColor, string format, params object[] args)
		{
			lock(_syncRoot)
			{
				var originalColor = this.ForegroundColor;
				this.ForegroundColor = foregroundColor;

				Console.Write(format, args);

				this.ForegroundColor = originalColor;
			}
		}

		public void WriteLine()
		{
			Console.WriteLine();
		}

		public void WriteLine(string text)
		{
			Console.WriteLine(text);
		}

		public void WriteLine(object value)
		{
			Console.WriteLine(value);
		}

		public void WriteLine(CommandOutletColor foregroundColor, string text)
		{
			lock(_syncRoot)
			{
				var originalColor = this.ForegroundColor;
				this.ForegroundColor = foregroundColor;

				Console.WriteLine(text);

				this.ForegroundColor = originalColor;
			}
		}

		public void WriteLine(CommandOutletColor foregroundColor, object value)
		{
			lock(_syncRoot)
			{
				var originalColor = this.ForegroundColor;
				this.ForegroundColor = foregroundColor;

				Console.WriteLine(value);

				this.ForegroundColor = originalColor;
			}
		}

		public void WriteLine(string format, params object[] args)
		{
			Console.WriteLine(format, args);
		}

		public void WriteLine(CommandOutletColor foregroundColor, string format, params object[] args)
		{
			lock(_syncRoot)
			{
				var originalColor = this.ForegroundColor;
				this.ForegroundColor = foregroundColor;

				Console.WriteLine(format, args);

				this.ForegroundColor = originalColor;
			}
		}

		#endregion

		#region 显式实现

		Encoding ICommandOutlet.Encoding
		{
			get
			{
				return Console.OutputEncoding;
			}
			set
			{
				Console.OutputEncoding = value;
			}
		}

		TextWriter ICommandOutlet.Writer
		{
			get
			{
				return Console.Out;
			}
		}

		#endregion

		#region 私有方法

		private CommandOutletColor ConvertColor(ConsoleColor color, CommandOutletColor defaultColor)
		{
			CommandOutletColor result;

			if(Enum.TryParse<CommandOutletColor>(color.ToString(), out result))
			{
				return result;
			}
			else
			{
				return defaultColor;
			}
		}

		private ConsoleColor ConvertColor(CommandOutletColor color, ConsoleColor defaultColor)
		{
			ConsoleColor result;

			if(Enum.TryParse<ConsoleColor>(color.ToString(), out result))
			{
				return result;
			}
			else
			{
				return defaultColor;
			}
		}

		#endregion
	}
}