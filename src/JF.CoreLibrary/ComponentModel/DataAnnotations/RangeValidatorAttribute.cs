using System;
using JF.Resources;
using System.ComponentModel.DataAnnotations;

namespace JF.ComponentModel.DataAnnotations
{
	/// <summary>
	/// 指定动态数据中数据字段值的数值范围约束。 
	/// </summary>
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = true)]
	public class RangeValidatorAttribute : ValidatorAttribute
	{
		#region 私有变量

		private RangeAttribute _rangeAttribute;

		#endregion

		#region 构造方法

		private RangeValidatorAttribute() : base(ResourceUtility.GetString("${Text.RangeValidator.ValidationError}"))
		{
		}

		/// <summary>
		/// 使用指定的最小值和最大值初始化 RangeValidatorAttribute 类的一个新实例。 
		/// </summary>
		/// <param name="minimum">指定数据字段值所允许的最小值。</param>
		/// <param name="maximum">指定数据字段值所允许的最大值。</param>
		public RangeValidatorAttribute(int minimum, int maximum) : this()
		{
			_rangeAttribute = new RangeAttribute(minimum, maximum);
		}

		/// <summary>
		/// 使用指定的最小值和最大值初始化 RangeValidatorAttribute 类的一个新实例。
		/// </summary>
		/// <param name="minimum">指定数据字段值所允许的最小值。</param>
		/// <param name="maximum">指定数据字段值所允许的最大值。</param>
		public RangeValidatorAttribute(double minimum, double maximum) : this()
		{
			_rangeAttribute = new RangeAttribute(minimum, maximum);
		}

		/// <summary>
		/// 使用指定的最小值和最大值以及特定类型初始化 RangeAttribute 类的一个新实例。 
		/// </summary>
		/// <param name="type">指定要测试的对象的类型。</param>
		/// <param name="minimum">指定数据字段值所允许的最小值。</param>
		/// <param name="maximum">指定数据字段值所允许的最大值。</param>
		public RangeValidatorAttribute(Type type, string minimum, string maximum) : this()
		{
			_rangeAttribute = new RangeAttribute(type, minimum, maximum);
		}

		#endregion

		#region 重写方法

		/// <inheritdoc />
		public override bool IsValid(object value)
		{
			return _rangeAttribute.IsValid(value);
		}

		/// <inheritdoc />
		public override string FormatErrorMessage(string name)
		{
			return string.Format(ErrorMessageString, name, _rangeAttribute.Minimum, _rangeAttribute.Maximum);
		}

		#endregion
	}
}