using System;
using System.ComponentModel;

namespace JF.Runtime.Serialization
{
	public enum SerializationMemberBehavior
	{
		/// <summary>未定义，默认状态。</summary>
		None,

		/// <summary>忽略序列化对应的成员。</summary>
		Ignored,

		/// <summary>必须序列化对应的成员。</summary>
		Required,
	}
}