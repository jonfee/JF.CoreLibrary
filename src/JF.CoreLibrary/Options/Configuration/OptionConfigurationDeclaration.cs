using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JF.Options.Configuration
{
	public class OptionConfigurationDeclaration
	{
		#region 成员字段

		private string _name;
		private Type _type;

		#endregion

		#region 构造方法

		public OptionConfigurationDeclaration(string name, Type type)
		{
			if(string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("name");
			}

			if(type == null)
			{
				throw new ArgumentNullException("type");
			}

			if(!typeof(OptionConfigurationElement).IsAssignableFrom(type))
			{
				throw new ArgumentException();
			}

			_name = name.Trim();
			_type = type;
		}

		#endregion

		#region 公共属性

		public string Name
		{
			get
			{
				return _name;
			}
		}

		public Type Type
		{
			get
			{
				return _type;
			}
		}

		#endregion
	}
}