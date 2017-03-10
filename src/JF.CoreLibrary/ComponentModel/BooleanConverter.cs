using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace JF.ComponentModel
{
	public class BooleanConverter : System.ComponentModel.BooleanConverter
	{
		#region 成员字段

		private string _trueString;
		private string _falseString;
		private static readonly Regex _digits = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$", RegexOptions.Compiled);

		#endregion

		#region 构造方法

		public BooleanConverter() : this("是", "否")
		{
		}

		public BooleanConverter([LocalizableAttribute(true)] string trueString, [LocalizableAttribute(true)] string falseString)
		{
			if(string.IsNullOrEmpty(trueString))
				_trueString = bool.TrueString;
			else
				_trueString = trueString;

			if(string.IsNullOrEmpty(falseString))
				_falseString = bool.FalseString;
			else
				_falseString = falseString;
		}

		#endregion

		#region 公共属性

		[LocalizableAttribute(true)]
		public string TrueString
		{
			get
			{
				return _trueString;
			}
			set
			{
				if(string.IsNullOrEmpty(value))
					value = bool.TrueString;

				if(string.Equals(_trueString, value, StringComparison.Ordinal))
					return;

				_trueString = value;
			}
		}

		[LocalizableAttribute(true)]
		public string FalseString
		{
			get
			{
				return _falseString;
			}
			set
			{
				if(string.IsNullOrEmpty(value))
					value = bool.FalseString;

				if(string.Equals(_falseString, value, StringComparison.Ordinal))
					return;

				_falseString = value;
			}
		}

		#endregion

		#region 重写方法

		public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
		{
			if(value is string)
			{
				bool result;

				if(bool.TryParse((string)value, out result))
					return result;

				if(string.Equals((string)value, "yes", StringComparison.OrdinalIgnoreCase) || string.Equals((string)value, "on", StringComparison.OrdinalIgnoreCase))
					return true;

				if(string.Equals(_trueString, (string)value, StringComparison.OrdinalIgnoreCase))
					return true;
				if(string.Equals(_falseString, (string)value, StringComparison.OrdinalIgnoreCase))
					return false;

				if(_digits.IsMatch((string)value))
				{
					var number = Convert.ToInt32((string)value, CultureInfo.InvariantCulture);

					if(number == 1)
						return true;

					if(number == 0)
						return false;
				}

				if(string.IsNullOrWhiteSpace((string)value) && this.IsNullable(context.PropertyDescriptor.PropertyType))
					return null;
				else
					return false;
			}

			return base.ConvertFrom(context, culture, value);
		}

		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
		{
			if(destinationType == typeof(string))
			{
				if(value == null)
					return null;

				return (bool)value ? _trueString : _falseString;
			}

			return base.ConvertTo(context, culture, value, destinationType);
		}

		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			if(this.IsNullable(context.PropertyDescriptor.PropertyType))
				return new TypeConverter.StandardValuesCollection(new object[]
				{
					null, true, false
				});
			else
				return new TypeConverter.StandardValuesCollection(new object[]
				{
					true, false
				});
		}

		#endregion

		#region 私有方法

		private bool IsNullable(Type propertyType)
		{
			if(propertyType == null)
				return false;

			return propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>);
		}

		#endregion
	}
}