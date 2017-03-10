using System;
using System.ComponentModel.DataAnnotations;

namespace JF.ComponentModel.DataAnnotations
{
    /// <summary>
    /// 指定要与数据字段关联的附加类型的名称。 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = true)]
	public class DataTypeValidatorAttribute : ValidatorAttribute
	{
		#region 私有变量

		private DataTypeAttribute _dataTypeAttribute;

		#endregion

		#region 构造方法

		/// <summary>
		/// 使用指定的类型名称初始化 <see cref="DataTypeValidatorAttribute"/> 类的新实例。 
		/// </summary>
		/// <param name="dataType">要与数据字段关联的类型的名称。</param>
		public DataTypeValidatorAttribute(DataType dataType)
		{
			_dataTypeAttribute = new DataTypeAttribute(dataType);
		}

		/// <summary>
		/// 使用指定的字段模板名称初始化 <see cref="DataTypeValidatorAttribute"/> 类的新实例。 
		/// </summary>
		/// <param name="customDataType">要与数据字段关联的自定义字段模板的名称。</param>
		public DataTypeValidatorAttribute(string customDataType)
		{
			_dataTypeAttribute = new DataTypeAttribute(customDataType);
		}

		#endregion

		#region 重写方法

		/// <inheritdoc />
		public override bool IsValid(object value)
		{
			return _dataTypeAttribute.IsValid(value);
		}

		/// <inheritdoc />
		public override string FormatErrorMessage(string name)
		{
			return _dataTypeAttribute.FormatErrorMessage(name);
		}

		#endregion
	}
}