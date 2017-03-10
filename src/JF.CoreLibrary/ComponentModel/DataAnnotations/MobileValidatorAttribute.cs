using System;
using JF.Text;
using System.ComponentModel.DataAnnotations;
using JF.Resources;

namespace JF.ComponentModel.DataAnnotations
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = true)]
	public class MobileValidatorAttribute : DataTypeValidatorAttribute
	{
		#region 构造方法

		public MobileValidatorAttribute() : base(DataType.PhoneNumber)
		{
			this.ErrorMessage = ResourceUtility.GetString("${Text.MobileValidator.Invalid}");
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

			return TextRegular.Chinese.Cellphone.IsMatch(valueString);
		}

		#endregion
	}
}