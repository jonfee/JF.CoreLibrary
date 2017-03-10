using System;
using System.Linq;
using JF.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JF.ComponentModel.DataAnnotations
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = true)]
	public class FileExtensionsValidatorAttribute : DataTypeValidatorAttribute
	{
		#region 成员字段

		private string _extensions;

		#endregion

		#region 公共属性

		public string Extensions
		{
			get
			{
				return string.IsNullOrWhiteSpace(_extensions) ? "png,jpg,jpeg,gif" : _extensions;
			}
			set
			{
				_extensions = value;
			}
		}

		#endregion

		#region 私有属性

		private string ExtensionsFormatted
		{
			get
			{
				return this.ExtensionsParsed.Aggregate((left, right) => left + ", " + right);
			}
		}

		private string ExtensionsNormalized
		{
			get
			{
				return this.Extensions.Replace(" ", string.Empty).Replace(".", string.Empty).ToLowerInvariant();
			}
		}

		private IEnumerable<string> ExtensionsParsed
		{
			get
			{
				return this.ExtensionsNormalized.Split(',').Select(e => "." + e);
			}
		}

		#endregion

		#region 构造方法

		public FileExtensionsValidatorAttribute() : base(DataType.Upload)
		{
			this.ErrorMessage = ResourceUtility.GetString("${Text.FileExtensionsValidator.Invalid}");
		}

		#endregion

		#region 重写方法

		public override string FormatErrorMessage(string name)
		{
			return string.Format(this.ErrorMessageString, name, ExtensionsFormatted);
		}

		public override bool IsValid(object value)
		{
			if(value == null)
				return true;

			var valueString = value as string;

			if(valueString != null)
				return this.ValidateExtension(valueString);

			return false;
		}

		#endregion

		#region 私有方法

		private bool ValidateExtension(string fileName)
		{
			try
			{
				return ExtensionsParsed.Contains(System.IO.Path.GetExtension(fileName).ToLowerInvariant());
			}
			catch(ArgumentException)
			{
				return false;
			}
		}

		#endregion
	}
}