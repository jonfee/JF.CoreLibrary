using System;

namespace JF.Options
{
	public interface IOptionViewBuilder
	{
		bool IsValid(IOptionView view);

		IOptionView GetView(IOption option);
	}
}