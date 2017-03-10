using System;

namespace JF.Common
{
	public interface IObjectReference<T> where T : class
	{
		/// <summary>
		/// 获取一个指示<seealso cref="Target"/>属性对应的目标对象是否可用的值。
		/// </summary>
		/// <remarks>
		///		<para>获取该属性始终不会抛出异常，如果目标对象已经是 Disposed 的则返回假(false)。</para>
		/// </remarks>
		bool HasTarget
		{
			get;
		}

		/// <summary>
		/// 获取引用的目标对象。
		/// </summary>
		T Target
		{
			get;
		}
	}
}