using System;
using System.Collections;
using JF.Common;
using JF.Resources;

namespace JF.ComponentModel.DataAnnotations
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = true)]
	public class MaxLengthValidatorAttribute : ValidatorAttribute
	{
		#region 常量定义

		private const int MaxAllowableLength = -1;

		#endregion

		#region 公共属性

		public int Length
		{
			get;
			private set;
		}

		#endregion

		#region 静态属性

		private static string DefaultErrorMessageString
		{
			get
			{
				return ResourceUtility.GetString("${Text.MaxLengthValidator.ValidationError}");
			}
		}

		#endregion

		#region 构造方法

		public MaxLengthValidatorAttribute() : this(MaxAllowableLength)
		{
		}

		public MaxLengthValidatorAttribute(int length) : base(DefaultErrorMessageString)
		{
			this.Length = length;
		}

		#endregion

		#region 重写方法

		public override string FormatErrorMessage(string name)
		{
			return string.Format(this.ErrorMessageString, name, Length);
		}

		public override bool IsValid(object value)
		{
			if(this.Length == 0 || this.Length < -1)
				throw new InvalidOperationException("MaxLengthValidatorAttribute must have a Length value that is greater than zero. Use MaxLengthValidator() without parameters to indicate that the string or array can have the maximum allowable length.");

			if(value == null)
				return true;

			var length = 0;
			var valueString = value as string;

			if(valueString != null)
			{
				length = valueString.Length;
			}
			else
			{
				var collection = value as ICollection;

				length = collection != null ? collection.Count : ((Array)value).Length;
			}

			return MaxAllowableLength == Length || length <= Length;
		}

		#endregion
	}
}