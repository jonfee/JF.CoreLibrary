using System;
using JF.Common;
using JF.Resources;

namespace JF.ComponentModel.DataAnnotations
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = true)]
	public class EnumValidatorAttribute : DataTypeValidatorAttribute
	{
		#region 公共属性

		public Type EnumType
		{
			get;
			private set;
		}

		#endregion

		#region 构造方法

		public EnumValidatorAttribute(Type enumType) : base("Enumeration")
		{
			if(enumType == null)
				throw new ArgumentNullException("enumType");

			this.EnumType = enumType;
			this.ErrorMessage = ResourceUtility.GetString("${Text.EnumValidator.ValidationError}");
		}

		#endregion

		#region 重写方法

		public override string FormatErrorMessage(string name)
		{
			return string.Format(this.ErrorMessage, name, this.EnumType.FullName);
		}

		public override bool IsValid(object value)
		{
			if(this.EnumType == null)
				throw new InvalidOperationException("The type provided for EnumDataTypeAttribute cannot be null.");

			if(!this.EnumType.IsEnum)
				throw new InvalidOperationException(string.Format("The type '{0}' needs to represent an enumeration type.", this.EnumType.FullName));

			if(value == null)
				return true;

			var stringValue = value as string;

			if(stringValue != null && string.IsNullOrEmpty(stringValue))
				return true;

			var valueType = value.GetType();

			// 匹配枚举类型。
			if(valueType.IsEnum && this.EnumType != valueType)
				return false;

			object result;

			return JF.Common.Convert.TryConvertValue(value, this.EnumType, out result);
		}

		#endregion
	}
}