using System;
using System.Collections;
using System.Collections.Generic;

namespace JF.Data
{
	/// <summary>
	/// 表示数据过滤条件的设置项。
	/// </summary>
	public class Condition : ICondition
	{
		#region 公共属性

		/// <summary>
		/// 获取条件名。
		/// </summary>
		public string Name
		{
			get;
			protected set;
		}

		/// <summary>
		/// 获取操作符。
		/// </summary>
		public ConditionOperator Operator
		{
			get;
			protected set;
		}

		/// <summary>
		/// 获取条件值。
		/// </summary>
		public object Value
		{
			get;
			protected set;
		}

		#endregion

		#region 构造方法

		/// <summary>
		/// 初始化 <see cref="Condition"/> 类的新实例。
		/// </summary>
		protected Condition()
		{

		}

		/// <summary>
		/// 初始化 <see cref="Condition"/> 类的新实例。s
		/// </summary>
		/// <param name="name">条件名。</param>
		/// <param name="value">条件值。</param>
		public Condition(string name, object value) : this(name, ConditionOperator.Equals, value)
		{

		}

		/// <summary>
		/// 初始化 <see cref="Condition"/> 类的新实例。
		/// </summary>
		/// <param name="name">条件名。</param>
		/// <param name="operator">操作符。</param>
		/// <param name="value">条件值。</param>
		public Condition(string name, ConditionOperator @operator, object value = null)
		{
			if(string.IsNullOrEmpty(name))
				throw new ArgumentNullException(nameof(name));

			this.Name = name;
			this.Operator = @operator;
			this.Value = value;
		}

		#endregion

		#region 公共方法

		public IEnumerable GetValues()
		{
			var items = this.Value as IEnumerable;

			if(items == null)
				yield return this.Value;
			else
			{
				foreach(var item in items)
					yield return item;
			}
		}

		public IEnumerable<T> GetValues<T>()
		{
			var items = this.Value as IEnumerable<T>;

			if(items == null)
				yield return (T)this.Value;
			else
			{
				foreach(T item in items)
					yield return item;
			}
		}

		#endregion
	}
}
