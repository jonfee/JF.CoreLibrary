using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace JF.Options
{
	/// <summary>
	/// �ṩѡ�����ݵĻ�ȡ�뱣�档
	/// </summary>
	public interface IOptionProvider
	{
		/// <summary>
		/// ����ָ����ѡ��·����ȡ��Ӧ��ѡ�����ݡ�
		/// </summary>
		/// <param name="path">Ҫ��ȡ��ѡ��·����</param>
		/// <returns>��ȡ����ѡ�����ݶ���</returns>
		object GetOptionObject(string path);

		/// <summary>
		/// ��ָ����ѡ�����ݱ��浽ָ��·���Ĵ洢�����С�
		/// </summary>
		/// <param name="path">�������ѡ��·����</param>
		/// <param name="optionObject">�������ѡ�����</param>
		void SetOptionObject(string path, object optionObject);
	}
}