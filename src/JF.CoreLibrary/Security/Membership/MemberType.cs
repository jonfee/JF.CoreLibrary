using System;
using System.ComponentModel;

namespace JF.Security.Membership
{
	/// <summary>
	/// ��ʾ��ɫ��Ա�����͡�
	/// </summary>
	public enum MemberType : byte
	{
		/// <summary>�û���Ա��</summary>
		[Description("�û�")]
		User = 0,

		/// <summary>��ɫ��Ա��</summary>
		[Description("��ɫ")]
		Role = 1
	}
}