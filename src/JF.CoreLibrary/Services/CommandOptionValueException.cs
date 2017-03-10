using System;
using System.Collections.Generic;

namespace JF.Services
{
	[Serializable]
	public class CommandOptionValueException : CommandOptionException
	{
		#region 成员字段

		private object _optionValue;

		#endregion

		#region 构造方法

		public CommandOptionValueException(string optionName, object optionValue) : base(optionName, Resources.ResourceUtility.GetString("InvalidCommandOptionValue", optionName, optionValue))
		{
			_optionValue = optionValue;
		}

		#endregion

		#region 公共属性

		public object OptionValue
		{
			get
			{
				return _optionValue;
			}
		}

		#endregion
	}
}