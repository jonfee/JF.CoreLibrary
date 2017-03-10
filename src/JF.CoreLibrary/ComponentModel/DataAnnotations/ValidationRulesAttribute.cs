using System;
using System.Collections.Generic;
using System.Linq;
using JF.Common;

namespace JF.ComponentModel.DataAnnotations
{
	/// <summary>
	/// 表示当前采用的验证规则特性。
	/// </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
	public class ValidationRulesAttribute : Attribute
	{
		#region 公共属性

		/// <summary>
		/// 获取验证规则列表。
		/// </summary>
		public IEnumerable<string> Rules
		{
			get;
			private set;
		}

		#endregion

		#region 构造方法

		public ValidationRulesAttribute(params string[] rules)
		{
			if(!rules.HasValue())
				throw new ArgumentNullException(nameof(rules));

			if(rules.Any(string.IsNullOrWhiteSpace))
				throw new ArgumentException();

			this.Rules = rules.Distinct().ToList();
		}

		#endregion
	}
}