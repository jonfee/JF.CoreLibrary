using System;
using System.Collections.Generic;

namespace JF.Services
{
	[AttributeUsage(AttributeTargets.Class)]
	public class MatcherAttribute : Attribute
	{
		#region 成员字段

		private Type _type;

		#endregion

		#region 构造方法

		public MatcherAttribute(Type type)
		{
			if(type == null)
			{
				throw new ArgumentNullException("type");
			}

			if(!typeof(IMatcher).IsAssignableFrom(type))
			{
				throw new ArgumentException("The type is not a IMatcher.");
			}

			_type = type;
		}

		public MatcherAttribute(string typeName)
		{
			if(string.IsNullOrWhiteSpace(typeName))
			{
				throw new ArgumentNullException("typeName");
			}

			var type = Type.GetType(typeName, false);

			if(type == null || !typeof(IMatcher).IsAssignableFrom(type))
			{
				throw new ArgumentException("The type is not a IMatcher.");
			}

			_type = type;
		}

		#endregion

		#region 公共属性

		public Type Type
		{
			get
			{
				return _type;
			}
		}

		public IMatcher Matcher
		{
			get
			{
				if(_type == null)
				{
					return null;
				}

				return Activator.CreateInstance(_type) as IMatcher;
			}
		}

		#endregion
	}
}