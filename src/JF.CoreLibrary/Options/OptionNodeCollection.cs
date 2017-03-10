using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace JF.Options
{
	public class OptionNodeCollection : JF.Collections.HierarchicalNodeCollection<OptionNode>
	{
		#region 构造方法

		internal OptionNodeCollection(OptionNode owner) : base(owner)
		{
		}

		#endregion

		#region 公共方法

		public OptionNode Add(string name, string title = null, string description = null)
		{
			if(string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("name");
			}

			var node = new OptionNode(name, title, description);
			this.Add(node);
			return node;
		}

		public OptionNode Add(string name, IOptionProvider provider, string title = null, string description = null)
		{
			if(string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("name");
			}

			OptionNode node = new OptionNode(name, title, description);

			if(provider != null)
			{
				node.Option = new Option(node, provider);
			}

			this.Add(node);
			return node;
		}

		#endregion
	}
}