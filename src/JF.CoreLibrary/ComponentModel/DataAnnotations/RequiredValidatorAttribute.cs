using System;
using JF.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace JF.ComponentModel.DataAnnotations
{
	/// <summary>
	/// 指定需要数据字段值。 
	/// </summary>
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = true)]
	public class RequiredValidatorAttribute : ValidatorAttribute
	{
		#region 公共属性

		public bool AllowEmptyStrings
		{
			get;
			set;
		}

		#endregion

		#region 构造方法

		public RequiredValidatorAttribute() : base(ResourceUtility.GetString("${Text.RequiredValidator.ValidationError}"))
		{

		}

		#endregion

		#region 重写方法

		/// <inheritdoc />
		public override bool IsValid(object value)
		{
			if(value == null)
				return false;

			var stringValue = value as string;

			if(stringValue != null && !this.AllowEmptyStrings)
				return stringValue.Trim().Length != 0;

			return true;
		}

		#endregion
	}
}