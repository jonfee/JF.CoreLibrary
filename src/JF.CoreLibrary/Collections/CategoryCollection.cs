using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace JF.Collections
{
	[Serializable]
	public class CategoryCollection : HierarchicalNodeCollection<Category>
	{
		#region ���췽��

		public CategoryCollection(Category owner) : base(owner)
		{
		}

		#endregion

		#region ��������

		public Category Add(string name, string title, string description)
		{
			var category = new Category(name, title, description);
			this.Add(category);
			return category;
		}

		#endregion
	}
}