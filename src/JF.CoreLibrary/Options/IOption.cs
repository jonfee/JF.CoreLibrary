using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace JF.Options
{
	/// <summary>
	/// 表示选项的基本功能定义，由 <seealso cref="JF.Options.Option"/> 类实现。
	/// </summary>
	/// <remarks>建议选项的实现者从 <see cref="JF.Options.Option"/> 基类继承。</remarks>
	public interface IOption
	{
		#region 事件定义

		event EventHandler Changed;

		event EventHandler Applied;

		event EventHandler Resetted;

		event CancelEventHandler Applying;

		event CancelEventHandler Resetting;

		#endregion

		#region 属性定义

		object OptionObject
		{
			get;
		}

		IOptionView View
		{
			get;
			set;
		}

		IOptionViewBuilder ViewBuilder
		{
			get;
			set;
		}

		IOptionProvider Provider
		{
			get;
		}

		bool IsDirty
		{
			get;
		}

		#endregion

		#region 方法定义

		void Reset();

		void Apply();

		#endregion
	}
}