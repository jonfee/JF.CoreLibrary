using System;
using JF.Text;
using JF.Resources;
using System.ComponentModel.DataAnnotations;

namespace JF.ComponentModel.DataAnnotations
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = true)]
	public class TelephoneValidatorAttribute : DataTypeValidatorAttribute
	{
		#region 构造方法

		public TelephoneValidatorAttribute() : base(DataType.PhoneNumber)
		{
			this.ErrorMessage = ResourceUtility.GetString("${Text.TelephoneValidator.Invalid}");
		}

		#endregion

		#region 重写方法

		public override bool IsValid(object value)
		{
			if(value == null)
				return true;

			var valueString = value as string;

			if(valueString == null)
				return false;

			return TextRegular.Chinese.Telephone.IsMatch(valueString);
		}

		#endregion
	}
}