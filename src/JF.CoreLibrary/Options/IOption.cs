using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace JF.Options
{
	/// <summary>
	/// ��ʾѡ��Ļ������ܶ��壬�� <seealso cref="JF.Options.Option"/> ��ʵ�֡�
	/// </summary>
	/// <remarks>����ѡ���ʵ���ߴ� <see cref="JF.Options.Option"/> ����̳С�</remarks>
	public interface IOption
	{
		#region �¼�����

		event EventHandler Changed;

		event EventHandler Applied;

		event EventHandler Resetted;

		event CancelEventHandler Applying;

		event CancelEventHandler Resetting;

		#endregion

		#region ���Զ���

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

		#region ��������

		void Reset();

		void Apply();

		#endregion
	}
}