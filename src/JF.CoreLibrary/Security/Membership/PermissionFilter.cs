using System;
using System.Collections.Generic;

namespace JF.Security.Membership
{
	[Serializable]
	public class PermissionFilter : Permission
	{
		#region 成员字段

		private string _filter;

		#endregion

		#region 构造方法

		public PermissionFilter()
		{
		}

		public PermissionFilter(long memberId, MemberType memberType, string schemaId, string actionId, string filter) : base(memberId, memberType, schemaId, actionId, false)
		{
			if(string.IsNullOrWhiteSpace(filter))
			{
				throw new ArgumentNullException("filter");
			}

			_filter = filter.Trim();
		}

		#endregion

		#region 公共属性

		public string Filter
		{
			get
			{
				return _filter;
			}
			set
			{
				_filter = value;
			}
		}

		#endregion

		#region 重写方法

		public override string ToString()
		{
			if(string.IsNullOrEmpty(_filter))
			{
				return base.ToString();
			}

			return base.ToString() + Environment.NewLine + _filter;
		}

		#endregion
	}
}