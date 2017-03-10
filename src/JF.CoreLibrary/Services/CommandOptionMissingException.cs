using System;

namespace JF.Services
{
	public class CommandOptionMissingException : CommandOptionException
	{
		public CommandOptionMissingException(string optionName) : base(optionName, Resources.ResourceUtility.GetString("MissingCommandOption", optionName))
		{
		}
	}
}