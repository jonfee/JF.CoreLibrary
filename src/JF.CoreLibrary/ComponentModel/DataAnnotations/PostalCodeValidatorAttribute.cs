using System;
using JF.Text;
using System.ComponentModel.DataAnnotations;
using JF.Resources;

namespace JF.ComponentModel.DataAnnotations
{
	public class PostalCodeValidatorAttribute : DataTypeValidatorAttribute
	{
		#region 构造方法

		public PostalCodeValidatorAttribute() : base(DataType.PostalCode)
		{
			this.ErrorMessage = ResourceUtility.GetString("${Text.PostalCodeValidator.Invalid}");
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

			return TextRegular.Chinese.PostalCode.IsMatch(valueString);
		}

		#endregion
	}
}