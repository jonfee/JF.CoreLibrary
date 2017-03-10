using System;
using System.ComponentModel;

namespace JF.Services
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	public class CommandOptionAttribute : Attribute
	{
		#region 成员字段

		private string _name;
		private object _defaultValue;
		private Type _type;
		private Type _converterType;
		private TypeConverter _converter;
		private bool _required;
		private string _description;

		#endregion

		#region 构造方法

		public CommandOptionAttribute(string name) : this(name, null)
		{
		}

		public CommandOptionAttribute(string name, Type type)
		{
			if(string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("name");
			}

			_name = name.Trim();
			_type = type;
			_defaultValue = JF.Common.Convert.GetDefaultValue(type);
			_required = false;
			_description = string.Empty;
		}

		public CommandOptionAttribute(string name, Type type, object defaultValue, string description) : this(name, type, defaultValue, false, description)
		{
		}

		public CommandOptionAttribute(string name, Type type, object defaultValue, bool required, string description)
		{
			if(string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("name");
			}

			if(type == null)
			{
				_defaultValue = defaultValue;
			}
			else
			{
				_defaultValue = JF.Common.Convert.ConvertValue(defaultValue, type);
			}

			_name = name;
			_type = type;
			_required = required;
			_description = description ?? string.Empty;
		}

		#endregion

		#region 公共属性

		/// <summary>
		/// 获取命令选项的名称。
		/// </summary>
		public string Name
		{
			get
			{
				return _name;
			}
		}

		/// <summary>
		/// 获取或设置命令选项是否必需的，默认值为假(false)。
		/// </summary>
		public bool Required
		{
			get
			{
				return _required;
			}
			set
			{
				_required = value;
			}
		}

		/// <summary>
		/// 获取或设置命令选项的值类型，如果返回空则表示当前选项没有值。
		/// </summary>
		public Type Type
		{
			get
			{
				return _type;
			}
			set
			{
				if(_type == value)
				{
					return;
				}

				if(_type != null)
				{
					throw new InvalidOperationException();
				}

				_type = value;
			}
		}

		/// <summary>
		/// 获取命令选项的值类型转换器。
		/// </summary>
		public TypeConverter Converter
		{
			get
			{
				if(_converter == null)
				{
					var converterType = _converterType;

					if(converterType != null)
					{
						System.Threading.Interlocked.CompareExchange(ref _converter, (TypeConverter)Activator.CreateInstance(converterType), null);
					}
				}

				return _converter;
			}
		}

		/// <summary>
		/// 获取或设置命令选项值的类型转换器的类型。
		/// </summary>
		public Type ConverterType
		{
			get
			{
				return _converterType;
			}
			set
			{
				if(_converterType == value)
				{
					return;
				}

				if(value != null && !typeof(TypeConverter).IsAssignableFrom(value))
				{
					throw new ArgumentException($"The '{value.FullName}' type is not TypeConverter.");
				}

				_converterType = value;
				_converter = null;
			}
		}

		/// <summary>
		/// 获取或设置命令选项的默认值。
		/// </summary>
		public object DefaultValue
		{
			get
			{
				return _defaultValue;
			}
			set
			{
				if(_type != null)
				{
					_defaultValue = JF.Common.Convert.ConvertValue(value, _type, () =>
					{
						var converter = this.Converter;

						if(converter != null)
						{
							return converter.ConvertFrom(value);
						}
						else
						{
							return JF.Common.Convert.GetDefaultValue(_type);
						}
					});
				}
				else
				{
					_defaultValue = value;
				}
			}
		}

		/// <summary>
		/// 获取或设置命令选项的文本描述。
		/// </summary>
		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				_description = value ?? string.Empty;
			}
		}

		#endregion
	}
}