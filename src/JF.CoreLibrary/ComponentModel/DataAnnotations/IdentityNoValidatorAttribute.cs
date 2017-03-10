using System;
using JF.Text;
using System.ComponentModel.DataAnnotations;
using JF.Resources;

namespace JF.ComponentModel.DataAnnotations
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = true)]
	public class IdentityNoValidatorAttribute : DataTypeValidatorAttribute
	{
		#region 构造方法

		public IdentityNoValidatorAttribute() : base(DataType.Text)
		{
			this.ErrorMessage = ResourceUtility.GetString("${Text.IdentityNoValidator.Invalid}");
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

			return TextRegular.Chinese.IdentityNo.IsMatch(valueString);
		}

		#endregion
	}
}