using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.Generic;

namespace JF.Terminals.Commands
{
	[DisplayName("${Text.ShellCommand.Title}")]
	[Description("${Text.ShellCommand.Description}")]
	[JF.Services.CommandOption("timeout", Type = typeof(int), DefaultValue = 1000, Description = "${Text.ShellCommand.Options.Timeout}")]
	public class ShellCommand : JF.Services.CommandBase<TerminalCommandContext>
	{
		#region 构造方法

		public ShellCommand() : base("Shell")
		{
		}

		public ShellCommand(string name) : base(name)
		{
		}

		#endregion

		#region 重写方法

		protected override object OnExecute(TerminalCommandContext context)
		{
			if(Environment.OSVersion.Platform == PlatformID.MacOSX || Environment.OSVersion.Platform == PlatformID.Unix)
			{
				throw new NotSupportedException(string.Format("Not supported in the {0} OS.", Environment.OSVersion));
			}

			if(context.Expression.Arguments.Length < 1)
			{
				return 0;
			}

			ProcessStartInfo info = new ProcessStartInfo(@"cmd.exe", " /C " + context.Expression.Arguments[0])
			{
				CreateNoWindow = true, UseShellExecute = false, RedirectStandardError = true, RedirectStandardInput = true, RedirectStandardOutput = true,
			};

			using(var process = Process.Start(info))
			{
				process.OutputDataReceived += delegate(object sender, DataReceivedEventArgs eventArgs)
				{
					context.Terminal.WriteLine(eventArgs.Data);
				};

				process.BeginOutputReadLine();

				//while(!process.StandardOutput.EndOfStream)
				//{
				//	context.Terminal.WriteLine(process.StandardOutput.ReadLine());
				//}

				//context.Terminal.Write(process.StandardOutput.ReadToEnd());

				//process.WaitForExit();

				if(!process.HasExited)
				{
					var timeout = context.Expression.Options.GetValue<int>("timeout");

					if(!process.WaitForExit(timeout > 0 ? timeout : int.MaxValue))
					{
						process.Close();
						return -1;
					}
				}

				return process.ExitCode;
			}
		}

		#endregion
	}
}