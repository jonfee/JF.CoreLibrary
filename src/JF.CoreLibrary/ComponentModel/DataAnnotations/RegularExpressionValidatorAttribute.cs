using System;
using JF.Resources;
using System.ComponentModel.DataAnnotations;

namespace JF.ComponentModel.DataAnnotations
{
	/// <summary>
	/// 指定数据字段值必须与指定的正则表达式匹配。
	/// </summary>
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = true)]
	public class RegularExpressionValidatorAttribute : ValidatorAttribute
	{
		#region 私有变量

		private RegularExpressionAttribute _regularExpressionAttribute;

		#endregion

		#region 构造方法

		/// <summary>
		/// 初始化 <see cref="RegularExpressionValidatorAttribute"/> 类的新实例。 
		/// </summary>
		/// <param name="pattern">用于验证数据字段值的正则表达式。</param>
		public RegularExpressionValidatorAttribute(string pattern) : base(ResourceUtility.GetString("${Text.RegularExpressionValidator.ValidationError}"))
		{
			if(string.IsNullOrEmpty(pattern))
				throw new ArgumentNullException(pattern);

			_regularExpressionAttribute = new RegularExpressionAttribute(pattern);
		}

		#endregion

		#region 重写方法

		/// <inheritdoc />
		public override bool IsValid(object value)
		{
			return _regularExpressionAttribute.IsValid(value);
		}

		/// <inheritdoc />
		public override string FormatErrorMessage(string name)
		{
			return string.Format(this.ErrorMessageString, name, _regularExpressionAttribute.Pattern);
		}

		#endregion
	}
}