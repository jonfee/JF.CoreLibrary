using System;

namespace JF.Text
{
	public interface ITextRegular : JF.Services.IMatchable<string>
	{
		bool IsMatch(string text, out string result);
	}
}