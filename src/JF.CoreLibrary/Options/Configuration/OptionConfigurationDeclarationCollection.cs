﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace JF.Options.Configuration
{
	public class OptionConfigurationDeclarationCollection : JF.Collections.NamedCollectionBase<OptionConfigurationDeclaration>
	{
		#region 构造方法

		public OptionConfigurationDeclarationCollection() : base(StringComparer.OrdinalIgnoreCase)
		{
		}

		#endregion

		#region 公共方法

		public OptionConfigurationDeclaration Add(string name, Type type)
		{
			var item = new OptionConfigurationDeclaration(name, type);
			this.Add(item);
			return item;
		}

		#endregion

		#region 重写方法

		protected override string GetKeyForItem(OptionConfigurationDeclaration item)
		{
			return item.Name;
		}

		#endregion
	}
}