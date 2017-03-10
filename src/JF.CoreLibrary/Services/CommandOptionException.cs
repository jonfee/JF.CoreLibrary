using System;
using System.Collections.Generic;

namespace JF.Services
{
	[Serializable]
	public class CommandOptionException : JF.Services.CommandException
	{
		#region 成员字段

		private string _optionName;

		#endregion

		#region 构造方法

		public CommandOptionException(string optionName) : this(optionName, Resources.ResourceUtility.GetString("InvalidCommandOption", optionName))
		{
		}

		public CommandOptionException(string optionName, string message) : base(message)
		{
			if(string.IsNullOrWhiteSpace(optionName))
			{
				throw new ArgumentNullException("optionName");
			}

			_optionName = optionName.Trim();
		}

		#endregion

		#region 公共属性

		public string OptionName
		{
			get
			{
				return _optionName;
			}
		}

		#endregion
	}
}