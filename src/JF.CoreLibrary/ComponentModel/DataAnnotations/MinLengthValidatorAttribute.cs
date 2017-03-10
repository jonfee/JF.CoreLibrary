using System;
using System.Collections;
using JF.Resources;

namespace JF.ComponentModel.DataAnnotations
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = true)]
	public class MinLengthValidatorAttribute : ValidatorAttribute
	{
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
				return ResourceUtility.GetString("${Text.MinLengthValidator.ValidationError}");
			}
		}

		#endregion

		#region 构造方法

		public MinLengthValidatorAttribute(int length) : base(DefaultErrorMessageString)
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
			if(this.Length < 0)
				throw new InvalidOperationException("MinLengthValidatorAttribute must have a Length value that is zero or greater.");

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

			return length >= this.Length;
		}

		#endregion
	}
}