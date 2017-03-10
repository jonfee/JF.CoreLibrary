using JF.Resources;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace JF.ComponentModel.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
	public class CompareValidatorAttribute : ValidatorAttribute
	{
		#region 公共属性

		public string OtherProperty
		{
			get;
			private set;
		}

		public string OtherPropertyDisplayName
		{
			get;
			internal set;
		}

		public override bool RequiresValidationContext
		{
			get
			{
				return true;
			}
		}

		#endregion

		#region 构造方法

		public CompareValidatorAttribute(string otherProperty) : base(ResourceUtility.GetString("${Text.CompareValidator.MustMatch}"))
		{
			if(string.IsNullOrWhiteSpace(otherProperty))
				throw new ArgumentNullException("otherProperty");

			this.OtherProperty = otherProperty;
		}

		#endregion

		#region 重写方法

		public override string FormatErrorMessage(string name)
		{
			return string.Format(this.ErrorMessageString, name, this.OtherPropertyDisplayName ?? this.OtherProperty);
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var otherPropertyInfo = validationContext.ObjectType.GetRuntimeProperty(OtherProperty);

			if(otherPropertyInfo == null)
				return new ValidationResult(string.Format("Could not find a property named '{0}'.", OtherProperty));

			var otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

			if(!Equals(value, otherPropertyValue))
			{
				if(OtherPropertyDisplayName == null)
					OtherPropertyDisplayName = GetDisplayNameForProperty(validationContext.ObjectType, OtherProperty);

				return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
			}

			return null;
		}

		#endregion

		#region 私有方法

		private static string GetDisplayNameForProperty(Type containerType, string propertyName)
		{
			var typeDescriptor = GetTypeDescriptor(containerType);
			var property = typeDescriptor.GetProperties().Find(propertyName, true);

			if(property == null)
				throw new ArgumentException(string.Format("The property '{0}.{1}' could not be found.", containerType.FullName, propertyName));

			var attributes = property.Attributes.Cast<Attribute>();
			var display = attributes.OfType<DisplayAttribute>().FirstOrDefault();

			if(display != null)
				return display.GetName();

			var displayName = attributes.OfType<DisplayNameAttribute>().FirstOrDefault();

			if(displayName != null)
				return displayName.DisplayName;

			return propertyName;
		}

		private static bool IsPublic(PropertyInfo property)
		{
			return (property.GetMethod != null && property.GetMethod.IsPublic) || (property.SetMethod != null && property.SetMethod.IsPublic);
		}

		private static ICustomTypeDescriptor GetTypeDescriptor(Type type)
		{
			return new AssociatedMetadataTypeTypeDescriptionProvider(type).GetTypeDescriptor(type);
		}

		#endregion
	}
}