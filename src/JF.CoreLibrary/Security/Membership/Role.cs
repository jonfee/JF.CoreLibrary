using System;
using System.Collections.Generic;

namespace JF.Security.Membership
{
	/// <summary>
	/// 表示角色的实体类。
	/// </summary>
	[Serializable]
	public class Role : JF.ComponentModel.NotifyObject
	{
		#region 静态字段

		public static readonly string Administrators = "Administrators";
		public static readonly string Securities = "Securities";

		#endregion

		#region 成员字段

		private long _roleId;
		private string _name;
		private string _fullName;
		private string _namespace;
		private string _description;
		private DateTime _createdTime;

		#endregion

		#region 构造方法

		public Role()
		{
			_createdTime = DateTime.Now;
		}

		public Role(string name, string @namespace) : this(0, name, @namespace)
		{
		}

		public Role(long roleId, string name) : this(roleId, name, null)
		{
		}

		public Role(long roleId, string name, string @namespace)
		{
			if(string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("name");
			}

			_roleId = roleId;
			this.Name = _fullName = name.Trim();
			this.Namespace = @namespace;
			_createdTime = DateTime.Now;
		}

		#endregion

		#region 公共属性

		public long RoleId
		{
			get
			{
				return _roleId;
			}
			set
			{
				this.SetPropertyValue(() => this.RoleId, ref _roleId, value);
			}
		}

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				//首先处理设置值为空或空字符串的情况
				if(string.IsNullOrWhiteSpace(value))
				{
					//如果当前角色名为空，则说明是通过默认构造方法创建，因此现在不用做处理；否则抛出参数空异常
					if(string.IsNullOrWhiteSpace(_name))
					{
						return;
					}

					throw new ArgumentNullException();
				}

				value = value.Trim();

				//角色名的长度必须不少于2个字符
				if(value.Length < 2)
				{
					throw new ArgumentOutOfRangeException();
				}

				//角色名的首字符必须是字母、下划线、美元符
				if(!(Char.IsLetter(value[0]) || value[0] == '_' || value[0] == '$'))
				{
					throw new ArgumentException("Invalid role name.");
				}

				//检查角色名的其余字符的合法性
				for(int i = 1; i < value.Length; i++)
				{
					//角色名的中间字符必须是字母、数字或下划线
					if(!Char.IsLetterOrDigit(value[i]) && value[i] != '_')
					{
						throw new ArgumentException("The role name contains invalid character.");
					}
				}

				//更新属性内容
				this.SetPropertyValue(() => this.Name, ref _name, value);
			}
		}

		public string FullName
		{
			get
			{
				return _fullName;
			}
			set
			{
				this.SetPropertyValue(() => this.FullName, ref _fullName, value);
			}
		}

		public string Namespace
		{
			get
			{
				return _namespace;
			}
			set
			{
				if(!string.IsNullOrWhiteSpace(value))
				{
					value = value.Trim();

					foreach(var chr in value)
					{
						//命名空间的字符必须是字母、数字、下划线或点号组成
						if(!Char.IsLetterOrDigit(chr) && chr != '_' && chr != '.')
						{
							throw new ArgumentException("The role namespace contains invalid character.");
						}
					}
				}

				//更新属性内容
				this.SetPropertyValue(() => this.Namespace, ref _namespace, string.IsNullOrWhiteSpace(value) ? null : value.Trim());
			}
		}

		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				this.SetPropertyValue(() => this.Description, ref _description, value);
			}
		}

		public DateTime CreatedTime
		{
			get
			{
				return _createdTime;
			}
			set
			{
				this.SetPropertyValue(() => this.CreatedTime, ref _createdTime, value);
			}
		}

		#endregion

		#region 重写方法

		public override bool Equals(object obj)
		{
			if(obj == null || obj.GetType() != this.GetType())
			{
				return false;
			}

			var other = (Role)obj;

			return _roleId == other._roleId && string.Equals(_namespace, other._namespace, StringComparison.OrdinalIgnoreCase);
		}

		public override int GetHashCode()
		{
			return (_namespace + ":" + _roleId).ToLowerInvariant().GetHashCode();
		}

		public override string ToString()
		{
			if(string.IsNullOrWhiteSpace(_namespace))
			{
				return string.Format("[{0}]{1}", _roleId, _name);
			}
			else
			{
				return string.Format("[{0}]{1}@{2}", _roleId, _name, _namespace);
			}
		}

		#endregion

		#region 静态方法

		public static bool IsBuiltin(Role role)
		{
			if(role == null)
			{
				return false;
			}

			return IsBuiltin(role.Name);
		}

		public static bool IsBuiltin(string roleName)
		{
			return string.Equals(roleName, Role.Administrators, StringComparison.OrdinalIgnoreCase) || string.Equals(roleName, Role.Securities, StringComparison.OrdinalIgnoreCase);
		}

		#endregion
	}
}