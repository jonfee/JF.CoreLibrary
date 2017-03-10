using System;
using System.Reflection;
using JF.Resources;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;

namespace JF.ComponentModel.DataAnnotations
{
	/// <summary>
	/// 所有验证属性的基类。
	/// </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
	public abstract class ValidatorAttribute : ValidationAttribute
	{
		#region 成员字段

		private object _typeId;

		#endregion

		#region 公共属性

		/// <summary>
		/// 获取或设置验证规则名称。
		/// </summary>
		public string RuleName
		{
			get;
			set;
		}

		#endregion

		#region 重写属性

		// 重写 TypeId 属性
		// 因为需要在相同的属性或者类型上应用多个同类的 ValidatorAttribute。
		public override object TypeId
		{
			get
			{
				return _typeId ?? (_typeId = new object());
			}
		}

		#endregion

		#region 构造方法

		protected ValidatorAttribute()
		{
			this.ErrorMessage = ResourceUtility.GetString("${Text.Validator.ValidationError}");
		}

		protected ValidatorAttribute(string errorMessage)
		{
			this.ErrorMessage = errorMessage;
		}

		#endregion

		#region 重写方法

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			this.ErrorMessage = this.ParseErrorMessage(value, validationContext);

			return base.IsValid(value, validationContext);
		}

		#endregion

		#region 私有方法

		private string ParseErrorMessage(object value, ValidationContext validationContext)
		{
			Assembly assembly = null;

			if(validationContext != null)
				assembly = validationContext.ObjectType.Assembly;

			if(assembly == null && value != null)
				assembly = value.GetType().Assembly;

			return assembly != null ? ResourceUtility.GetString(this.ErrorMessage, assembly) : ResourceUtility.GetString(this.ErrorMessage);
		}

		#endregion
	}
}