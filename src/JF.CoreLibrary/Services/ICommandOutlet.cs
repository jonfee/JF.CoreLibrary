using System;
using System.IO;
using System.Text;

namespace JF.Services
{
	public interface ICommandOutlet
	{
		Encoding Encoding
		{
			get;
			set;
		}

		TextWriter Writer
		{
			get;
		}

		void Write(string text);

		void Write(object value);

		void Write(string format, params object[] args);

		void Write(CommandOutletColor color, string text);

		void Write(CommandOutletColor color, object value);

		void Write(CommandOutletColor color, string format, params object[] args);

		void WriteLine();

		void WriteLine(string text);

		void WriteLine(object value);

		void WriteLine(string format, params object[] args);

		void WriteLine(CommandOutletColor color, string text);

		void WriteLine(CommandOutletColor color, object value);

		void WriteLine(CommandOutletColor color, string format, params object[] args);
	}
}