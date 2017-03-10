using System;
using System.Collections.Generic;

namespace JF.Security.Membership
{
	[Serializable]
	public class Permission
	{
		#region 成员字段

		private long _memberId;
		private MemberType _memberType;
		private string _schemaId;
		private string _actionId;
		private bool _granted;

		#endregion

		#region 构造方法

		public Permission()
		{
		}

		public Permission(long memberId, MemberType memberType, string schemaId, string actionId, bool granted)
		{
			if(string.IsNullOrEmpty(schemaId))
			{
				throw new ArgumentNullException("schemaId");
			}
			if(string.IsNullOrEmpty(actionId))
			{
				throw new ArgumentNullException("actionId");
			}

			_memberId = memberId;
			_memberType = memberType;
			_schemaId = schemaId;
			_actionId = actionId;
			_granted = granted;
		}

		#endregion

		#region 公共属性

		public long MemberId
		{
			get
			{
				return _memberId;
			}
			set
			{
				_memberId = value;
			}
		}

		public MemberType MemberType
		{
			get
			{
				return _memberType;
			}
			set
			{
				_memberType = value;
			}
		}

		public string SchemaId
		{
			get
			{
				return _schemaId;
			}
			set
			{
				if(string.IsNullOrEmpty(value))
				{
					throw new ArgumentNullException();
				}

				_schemaId = value;
			}
		}

		public string ActionId
		{
			get
			{
				return _actionId;
			}
			set
			{
				if(string.IsNullOrEmpty(value))
				{
					throw new ArgumentNullException();
				}

				_actionId = value;
			}
		}

		public bool Granted
		{
			get
			{
				return _granted;
			}
			set
			{
				_granted = value;
			}
		}

		#endregion

		#region 重写方法

		public override bool Equals(object obj)
		{
			if(obj == null || obj.GetType() != this.GetType())
			{
				return false;
			}

			var other = (Permission)obj;

			return _granted == other._granted && _memberId == other._memberId && _memberType == other._memberType && string.Equals(_schemaId, other._schemaId, StringComparison.OrdinalIgnoreCase) && string.Equals(_actionId, other._actionId, StringComparison.OrdinalIgnoreCase);
		}

		public override int GetHashCode()
		{
			return (_memberId + ":" + _memberType + ":" + _schemaId + ":" + _actionId + ":" + _granted.ToString()).ToLowerInvariant().GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("{0}[{1}]{2}:{3}({4})", _memberId, _memberType, _schemaId, _actionId, (_granted ? "Granted" : "Denied"));
		}

		#endregion
	}
}