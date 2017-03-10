using System;
using JF.Resources;

namespace JF.ComponentModel.DataAnnotations
{
	/// <summary>
	/// 指定数据字段中允许的字符长度范围约束。 
	/// </summary>
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = true)]
	public class StringLengthValidatorAttribute : ValidatorAttribute
	{
		#region 公共属性

		public int MaximumLength
		{
			get;
			private set;
		}

		public int MinimumLength
		{
			get;
			set;
		}

		public string IncludingMinimumErrorMessageString
		{
			get;
			set;
		}

		#endregion

		#region 构造方法

		/// <summary>
		/// 使用指定的最大长度初始化 <see cref="StringLengthValidatorAttribute"/> 类的新实例。 
		/// </summary>
		/// <param name="maximumLength">字符串的最大长度。</param>
		public StringLengthValidatorAttribute(int maximumLength) : this(0, maximumLength)
		{
		}

		/// <summary>
		/// 使用指定的最小长度和最大长度初始化 <see cref="StringLengthValidatorAttribute"/> 类的新实例。 
		/// </summary>
		/// <param name="minimumLength">字符串的最小长度。</param>
		/// <param name="maximumLength">字符串的最大长度。</param>
		public StringLengthValidatorAttribute(int minimumLength, int maximumLength) : base(ResourceUtility.GetString("${Text.StringLengthValidator.ValidationError}"))
		{
			this.MaximumLength = maximumLength;
			this.MinimumLength = minimumLength;
			this.IncludingMinimumErrorMessageString = ResourceUtility.GetString("${Text.StringLengthValidator.ValidationErrorIncludingMinimum}");
		}

		#endregion

		#region 重写方法

		/// <inheritdoc />
		public override bool IsValid(object value)
		{
			this.EnsureLegalLengths();

			var length = value == null ? 0 : ((string)value).Length;

			return value == null || (length >= MinimumLength && length <= MaximumLength);
		}

		/// <inheritdoc />
		public override string FormatErrorMessage(string name)
		{
			this.EnsureLegalLengths();

			var useErrorMessageWithMinimum = this.MinimumLength != 0 && !string.IsNullOrWhiteSpace(this.IncludingMinimumErrorMessageString);
			var errorMessage = useErrorMessageWithMinimum ? this.IncludingMinimumErrorMessageString : this.ErrorMessageString;

			return string.Format(errorMessage, name, this.MaximumLength, this.MinimumLength);
		}

		#endregion

		#region 私有方法

		private void EnsureLegalLengths()
		{
			if(this.MaximumLength < 0)
				throw new InvalidOperationException("The maximum length must be a nonnegative integer.");

			if(MaximumLength < MinimumLength)
				throw new InvalidOperationException(string.Format("The maximum value '{0}' must be greater than or equal to the minimum value '{1}'.", this.MaximumLength, this.MinimumLength));
		}

		#endregion
	}
}