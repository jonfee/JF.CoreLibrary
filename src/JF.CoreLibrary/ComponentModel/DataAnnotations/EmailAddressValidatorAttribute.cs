using JF.Resources;
using JF.Text;
using System;
using System.ComponentModel.DataAnnotations;

namespace JF.ComponentModel.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = true)]
	public class EmailAddressValidatorAttribute : DataTypeValidatorAttribute
	{
		#region 构造方法

		public EmailAddressValidatorAttribute() : base(DataType.EmailAddress)
		{
			this.ErrorMessage = ResourceUtility.GetString("${Text.EmailAddressValidator.Invalid}");
		}

		#endregion

		#region 重写方法

		public override bool IsValid(object value)
		{
			if(value == null)
				return true;

			var valueAsString = value as string;

			if(valueAsString == null)
				return false;

			return TextRegular.Web.Email.IsMatch(valueAsString);
		}

		#endregion
	}
}