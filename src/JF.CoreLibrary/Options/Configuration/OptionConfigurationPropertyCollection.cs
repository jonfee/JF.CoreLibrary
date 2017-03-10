using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace JF.Options.Configuration
{
	public class OptionConfigurationPropertyCollection : KeyedCollection<string, OptionConfigurationProperty>
	{
		public OptionConfigurationPropertyCollection() : base(StringComparer.OrdinalIgnoreCase)
		{
		}

		protected override string GetKeyForItem(OptionConfigurationProperty item)
		{
			return item.Name;
		}

		public bool TryGetValue(string name, out OptionConfigurationProperty value)
		{
			value = null;

			if(name == null)
			{
				name = string.Empty;
			}

			if(Contains(name))
			{
				value = this[name];
				return true;
			}

			return false;
		}
	}
}