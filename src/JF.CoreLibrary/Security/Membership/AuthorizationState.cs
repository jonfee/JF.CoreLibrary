using System;

namespace JF.Security.Membership
{
	public class AuthorizationState
	{
		#region 成员字段

		private string _schemaId;
		private string _actionId;

		#endregion

		#region 构造方法

		public AuthorizationState(string schemaId, string actionId)
		{
			if(string.IsNullOrWhiteSpace(schemaId))
			{
				throw new ArgumentNullException("schemaId");
			}
			if(string.IsNullOrWhiteSpace(actionId))
			{
				throw new ArgumentNullException("actionId");
			}

			_schemaId = schemaId.Trim();
			_actionId = actionId.Trim();
		}

		#endregion

		#region 公共属性

		/// <summary>
		/// 获取或设置授权目标代号。
		/// </summary>
		public string SchemaId
		{
			get
			{
				return _schemaId;
			}
			set
			{
				if(string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException();
				}

				_schemaId = value.Trim();
			}
		}

		/// <summary>
		/// 获取或设置授权行为代号。
		/// </summary>
		public string ActionId
		{
			get
			{
				return _actionId;
			}
			set
			{
				if(string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException();
				}

				_actionId = value.Trim();
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

			var other = (AuthorizationState)obj;

			return string.Equals(_schemaId, other._schemaId, StringComparison.OrdinalIgnoreCase) && string.Equals(_actionId, other._actionId, StringComparison.OrdinalIgnoreCase);
		}

		public override int GetHashCode()
		{
			return (_schemaId + ":" + _actionId).ToLowerInvariant().GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("{0}:{1}", _schemaId, _actionId);
		}

		#endregion
	}
}