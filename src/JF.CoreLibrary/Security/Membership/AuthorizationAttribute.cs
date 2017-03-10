using System;
using System.ComponentModel;

namespace JF.Security.Membership
{
	[AttributeUsage((AttributeTargets.Class | AttributeTargets.Method), AllowMultiple = false, Inherited = true)]
	public class AuthorizationAttribute : Attribute
	{
		#region 成员字段

		private string _schemaId;
		private string _actionId;
		private string[] _roles;
		private AuthorizationMode _mode;
		private Type _validatorType;
		private ICredentialValidator _validator;

		#endregion

		#region 构造方法

		public AuthorizationAttribute(AuthorizationMode mode)
		{
			_mode = mode;
		}

		public AuthorizationAttribute(string[] roles)
		{
			if(roles == null || roles.Length == 0)
			{
				throw new ArgumentNullException("roles");
			}

			_roles = roles;
			_mode = AuthorizationMode.Identity;
		}

		public AuthorizationAttribute(string schemaId) : this(schemaId, (string)null)
		{
		}

		public AuthorizationAttribute(string schemaId, string actionId)
		{
			_actionId = actionId ?? string.Empty;
			_schemaId = schemaId ?? string.Empty;

			_mode = AuthorizationMode.Required;
		}

		#endregion

		#region 公共属性

		/// <summary>
		/// 获取授权验证的方式。
		/// </summary>
		public AuthorizationMode Mode
		{
			get
			{
				return _mode;
			}
		}

		/// <summary>
		/// 获取操作编号。
		/// </summary>
		public string ActionId
		{
			get
			{
				return _actionId;
			}
		}

		/// <summary>
		/// 获取模式编号。
		/// </summary>
		public string SchemaId
		{
			get
			{
				return _schemaId;
			}
		}

		/// <summary>
		/// 获取验证的所属角色名数组。
		/// </summary>
		public string[] Roles
		{
			get
			{
				return _roles;
			}
		}

		/// <summary>
		/// 获取凭证验证器实例。
		/// </summary>
		public virtual ICredentialValidator Validator
		{
			get
			{
				if(_validator == null)
				{
					var type = this.ValidatorType;

					if(type == null)
					{
						return null;
					}

					lock(type)
					{
						if(_validator == null)
						{
							_validator = Activator.CreateInstance(type) as ICredentialValidator;
						}
					}
				}

				return _validator;
			}
		}

		/// <summary>
		/// 获取或设置凭证验证器的类型。
		/// </summary>
		public Type ValidatorType
		{
			get
			{
				return _validatorType;
			}
			set
			{
				if(_validatorType == value)
				{
					return;
				}

				if(value != null && !typeof(ICredentialValidator).IsAssignableFrom(value))
				{
					throw new ArgumentException();
				}

				_validatorType = value;
				_validator = null;
			}
		}

		#endregion
	}
}