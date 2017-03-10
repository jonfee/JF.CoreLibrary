using System;
using System.Collections.Generic;
using System.Text;

namespace JF.Services
{
	[Serializable]
	public class CommandExecutingEventArgs : EventArgs
	{
		#region 成员字段

		private CommandContext _context;
		private IDictionary<string, object> _extendedProperties;
		private object _parameter;
		private object _result;
		private bool _cancel;

		#endregion

		#region 构造方法

		public CommandExecutingEventArgs(CommandContext context, bool cancel = false)
		{
			if(context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			_context = context;
			_cancel = cancel;
		}

		public CommandExecutingEventArgs(object parameter, IDictionary<string, object> extendedProperties = null, bool cancel = false)
		{
			var context = parameter as CommandContext;

			if(context != null)
			{
				_context = context;

				if(extendedProperties != null && extendedProperties.Count > 0)
				{
					foreach(var pair in extendedProperties)
					{
						context.ExtendedProperties[pair.Key] = pair.Value;
					}
				}
			}
			else
			{
				_parameter = parameter;
				_extendedProperties = extendedProperties;
			}

			_cancel = cancel;
		}

		#endregion

		#region 公共属性

		/// <summary>
		/// 获取或设置一个值，表示是否取消当前命令的执行。
		/// </summary>
		public bool Cancel
		{
			get
			{
				return _cancel;
			}
			set
			{
				_cancel = value;
			}
		}

		/// <summary>
		/// 获取命令的执行上下文对象。
		/// </summary>
		public CommandContext Context
		{
			get
			{
				return _context;
			}
		}

		/// <summary>
		/// 获取命令的执行参数对象。
		/// </summary>
		public object Parameter
		{
			get
			{
				return _context != null ? _context.Parameter : _parameter;
			}
		}

		/// <summary>
		/// 获取或设置命令的执行结果。
		/// </summary>
		public object Result
		{
			get
			{
				return _result;
			}
			set
			{
				_result = value;
			}
		}

		public bool HasExtendedProperties
		{
			get
			{
				if(_context != null)
				{
					return _context.HasExtendedProperties;
				}
				else
				{
					return _extendedProperties != null && _extendedProperties.Count > 0;
				}
			}
		}

		/// <summary>
		/// 获取可用于在命令执行过程中在各处理模块之间组织和共享数据的键/值集合。
		/// </summary>
		public IDictionary<string, object> ExtendedProperties
		{
			get
			{
				if(_context != null)
				{
					return _context.ExtendedProperties;
				}

				if(_extendedProperties == null)
				{
					System.Threading.Interlocked.CompareExchange(ref _extendedProperties, new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase), null);
				}

				return _extendedProperties;
			}
		}

		#endregion
	}
}