using System;
using System.Collections.Generic;

namespace JF.Services
{
	public class Matcher : IMatcher
	{
		#region 单例字段

		public static readonly Matcher Default = new Matcher();

		#endregion

		#region 匹配方法

		public virtual bool Match(object target, object parameter)
		{
			if(target == null)
			{
				return false;
			}

			var matchable = target as IMatchable;

			if(matchable != null)
			{
				return matchable.IsMatch(parameter);
			}

			var attribute = (MatcherAttribute)Attribute.GetCustomAttribute(target.GetType(), typeof(MatcherAttribute), true);

			if(attribute != null && attribute.Matcher != null)
			{
				return attribute.Matcher.Match(target, parameter);
			}

			//注意：默认返回必须是真
			return true;
		}

		#endregion
	}
}