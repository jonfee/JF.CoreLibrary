using System;
using System.IO;

namespace JF.Services
{
	public class CommandExecutorContext : MarshalByRefObject
	{
		#region 成员字段

		private ICommandExecutor _executor;
		private CommandExpression _expression;
		private object _parameter;

		#endregion

		#region 构造方法

		public CommandExecutorContext(ICommandExecutor executor, CommandExpression expression, object parameter)
		{
			if(executor == null)
			{
				throw new ArgumentNullException(nameof(executor));
			}

			if(expression == null)
			{
				throw new ArgumentNullException(nameof(expression));
			}

			_executor = executor;
			_expression = expression;
			_parameter = parameter;
		}

		#endregion

		#region 公共属性

		/// <summary>
		/// 获取当前命令执行器对象。
		/// </summary>
		public ICommandExecutor Executor
		{
			get
			{
				return _executor;
			}
		}

		/// <summary>
		/// 获取当前命令执行器的命令表达式。
		/// </summary>
		public CommandExpression Expression
		{
			get
			{
				return _expression;
			}
		}

		/// <summary>
		/// 获取从命令执行器传入的参数值。
		/// </summary>
		public object Parameter
		{
			get
			{
				return _parameter;
			}
		}

		/// <summary>
		/// 获取当前命令执行器的标准输出器。
		/// </summary>
		public ICommandOutlet Output
		{
			get
			{
				return _executor.Output;
			}
		}

		/// <summary>
		/// 获取当前命令执行器的错误输出器。
		/// </summary>
		public TextWriter Error
		{
			get
			{
				return _executor.Error;
			}
		}

		#endregion
	}
}