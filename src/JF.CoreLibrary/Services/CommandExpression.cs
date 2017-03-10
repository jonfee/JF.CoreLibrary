using System;
using System.Collections.Generic;

namespace JF.Services
{
	public class CommandExpression
	{
		#region 成员字段

		private string _name;
		private string _path;
		private string _fullPath;
		private JF.IO.PathAnchor _anchor;
		private CommandOptionCollection _options;
		private string[] _arguments;
		private CommandExpression _next;

		#endregion

		#region 构造方法

		public CommandExpression(JF.IO.PathAnchor anchor, string name, string path, IDictionary<string, string> options, params string[] arguments)
		{
			if(string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException(nameof(name));
			}

			//修缮传入的路径参数值
			path = path.Trim('/', ' ', '\t', '\r', '\n');

			_anchor = anchor;
			_name = name.Trim();

			switch(anchor)
			{
				case IO.PathAnchor.Root:
					if(string.IsNullOrEmpty(path))
					{
						_path = "/";
					}
					else
					{
						_path = "/" + path + "/";
					}
					break;
				case IO.PathAnchor.Current:
					if(string.IsNullOrEmpty(path))
					{
						_path = "./";
					}
					else
					{
						_path = "./" + path + "/";
					}
					break;
				case IO.PathAnchor.Parent:
					if(string.IsNullOrEmpty(path))
					{
						_path = "../";
					}
					else
					{
						_path = "../" + path + "/";
					}
					break;
				default:
					if(string.IsNullOrEmpty(path))
					{
						_path = string.Empty;
					}
					else
					{
						_path = path + "/";
					}
					break;
			}

			_fullPath = _path + _name;

			if(options == null || options.Count == 0)
			{
				_options = new CommandOptionCollection();
			}
			else
			{
				_options = new CommandOptionCollection(options);
			}

			_arguments = arguments ?? new string[0];
		}

		#endregion

		#region 公共属性

		public JF.IO.PathAnchor Anchor
		{
			get
			{
				return _anchor;
			}
		}

		public string Name
		{
			get
			{
				return _name;
			}
		}

		public string Path
		{
			get
			{
				return _path;
			}
		}

		public string FullPath
		{
			get
			{
				return _fullPath;
			}
		}

		public CommandOptionCollection Options
		{
			get
			{
				return _options;
			}
		}

		public string[] Arguments
		{
			get
			{
				return _arguments;
			}
		}

		public CommandExpression Next
		{
			get
			{
				return _next;
			}
			set
			{
				_next = value;
			}
		}

		#endregion

		#region 解析方法

		public static CommandExpression Parse(string text)
		{
			return CommandExpressionParser.Instance.Parse(text);
		}

		#endregion

		#region 重写方法

		public override string ToString()
		{
			string result = this.FullPath;

			if(_options.Count > 0)
			{
				foreach(var option in _options)
				{
					if(string.IsNullOrWhiteSpace(option.Value))
					{
						result += string.Format(" /{0}", option.Key);
					}
					else
					{
						if(option.Value.Contains("\""))
						{
							result += $" -{option.Key}:'{option.Value}'";
						}
						else
						{
							result += $" -{option.Key}:\"{option.Value}\"";
						}
					}
				}
			}

			if(_arguments.Length > 0)
			{
				foreach(var argument in _arguments)
				{
					if(argument.Contains("\""))
					{
						result += $" '{argument}'";
					}
					else
					{
						result += $" \"{argument}\"";
					}
				}
			}

			var next = this.Next;

			if(next == null)
			{
				return result;
			}
			else
			{
				return result + " | " + next.ToString();
			}
		}

		#endregion
	}
}