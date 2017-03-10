using System;
using System.Collections.Generic;

namespace JF.Events
{
	/// <summary>
	/// 表示应用该属性的事件处理程序将处理一个异步事件。
	/// <remarks>此属性只适用于事件处理程序，并且只能通过事件总线调度应用。</remarks>
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class AsyncEventHandlerAttribute : Attribute
	{

	}
}
