﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace JF.Security
{
	/// <summary>
	/// 表示安全凭证的实体类。
	/// </summary>
	[Serializable]
	public class Credential
	{
		#region 常量定义

		private const string EXTENDEDPROPERTIESPREFIX = "ExtendedProperties.";

		#endregion

		#region 成员字段

		private string _credentialId;
		private string _scene;
		private DateTime _timestamp;
		private DateTime _issuedTime;
		private TimeSpan _duration;
		private Membership.User _user;
		private IDictionary<string, object> _extendedProperties;
		private Credential _innerCredential;

		#endregion

		#region 构造方法

		public Credential(string credentialId, Membership.User user, string scene, TimeSpan duration) : this(credentialId, user, scene, duration, DateTime.Now, null)
		{
		}

		public Credential(string credentialId, Membership.User user, string scene, TimeSpan duration, DateTime issuedTime, IDictionary<string, object> extendedProperties = null)
		{
			if(string.IsNullOrWhiteSpace(credentialId))
			{
				throw new ArgumentNullException("credentialId");
			}

			if(user == null)
			{
				throw new ArgumentNullException("user");
			}

			_user = user;
			_credentialId = credentialId.Trim();
			_scene = scene == null ? null : scene.Trim();
			_duration = duration;
			_issuedTime = issuedTime;
			_timestamp = issuedTime;

			if(extendedProperties != null && extendedProperties.Count > 0)
			{
				_extendedProperties = new Dictionary<string, object>(extendedProperties, StringComparer.OrdinalIgnoreCase);
			}
		}

		protected Credential(Credential innerCredential)
		{
			if(innerCredential == null)
			{
				throw new ArgumentNullException("innerCredential");
			}

			_innerCredential = innerCredential;
		}

		#endregion

		#region 公共属性

		/// <summary>
		/// 获取安全凭证编号。
		/// </summary>
		public string CredentialId
		{
			get
			{
				if(_innerCredential != null)
				{
					return _innerCredential.CredentialId;
				}

				return _credentialId;
			}
		}

		/// <summary>
		/// 获取安全凭证所属的命令空间。
		/// </summary>
		[JF.Runtime.Serialization.SerializationMember(Runtime.Serialization.SerializationMemberBehavior.Ignored)]
		public string Namespace
		{
			get
			{
				if(_innerCredential != null)
				{
					return _innerCredential.Namespace;
				}

				return _user == null ? null : _user.Namespace;
			}
		}

		/// <summary>
		/// 获取安全凭证的应用场景，譬如：Web、Mobile 等。
		/// </summary>
		public string Scene
		{
			get
			{
				if(_innerCredential != null)
				{
					return _innerCredential.Scene;
				}

				return _scene;
			}
		}

		/// <summary>
		/// 获取安全凭证对应的用户对象。
		/// </summary>
		public Membership.User User
		{
			get
			{
				if(_innerCredential != null)
				{
					return _innerCredential.User;
				}

				return _user;
			}
		}

		/// <summary>
		/// 获取安全凭证对应的用户编号。
		/// </summary>
		[JF.Runtime.Serialization.SerializationMember(Runtime.Serialization.SerializationMemberBehavior.Ignored)]
		public long UserId
		{
			get
			{
				if(_innerCredential != null)
				{
					return _innerCredential.UserId;
				}

				var user = _user;
				return user == null ? 0 : user.UserId;
			}
		}

		/// <summary>
		/// 获取或设置安全凭证的最后活动时间。
		/// </summary>
		public DateTime Timestamp
		{
			get
			{
				if(_innerCredential != null)
				{
					return _innerCredential.Timestamp;
				}

				return _timestamp;
			}
			set
			{
				if(_innerCredential != null)
				{
					_innerCredential.Timestamp = value;
				}
				else
				{
					_timestamp = value;
				}
			}
		}

		/// <summary>
		/// 获取安全凭证的签发时间。
		/// </summary>
		public DateTime IssuedTime
		{
			get
			{
				if(_innerCredential != null)
				{
					return _innerCredential.IssuedTime;
				}

				return _issuedTime;
			}
		}

		/// <summary>
		/// 获取安全凭证的有效期限。
		/// </summary>
		public TimeSpan Duration
		{
			get
			{
				if(_innerCredential != null)
				{
					return _innerCredential.Duration;
				}

				return _duration;
			}
		}

		/// <summary>
		/// 获取安全凭证的过期时间。
		/// </summary>
		/// <remarks>
		///		<para>该属性始终返回<see cref="Timestamp"/>属性加上<see cref="Duration"/>属性的值。</para>
		/// </remarks>
		[JF.Runtime.Serialization.SerializationMember(Runtime.Serialization.SerializationMemberBehavior.Ignored)]
		public DateTime Expires
		{
			get
			{
				if(_innerCredential != null)
				{
					return _innerCredential.Expires;
				}

				return _timestamp + _duration;
			}
		}

		/// <summary>
		/// 获取一个值，指示扩展属性集是否存在并且有值。
		/// </summary>
		[JF.Runtime.Serialization.SerializationMember(Runtime.Serialization.SerializationMemberBehavior.Ignored)]
		public bool HasExtendedProperties
		{
			get
			{
				if(_innerCredential != null)
				{
					return _innerCredential.HasExtendedProperties;
				}

				return _extendedProperties != null && _extendedProperties.Count > 0;
			}
		}

		/// <summary>
		/// 获取安全凭证的扩展属性集。
		/// </summary>
		public IDictionary<string, object> ExtendedProperties
		{
			get
			{
				if(_innerCredential != null)
				{
					return _innerCredential.ExtendedProperties;
				}

				if(_extendedProperties == null)
				{
					System.Threading.Interlocked.CompareExchange(ref _extendedProperties, new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase), null);
				}

				return _extendedProperties;
			}
		}

		#endregion

		#region 公共方法

		//public IDictionary<string, object> ToDictionary()
		//{
		//	var result = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
		//	{
		//		{"CertificationId", this.CertificationId},
		//		{"Scene", this.Scene},
		//		{"Duration", this.Duration},
		//		{"IssuedTime", this.IssuedTime},
		//		{"Timestamp", this.Timestamp},
		//	};

		//	if(_user != null)
		//	{
		//		result.Add(".User.Type", _user.GetType().AssemblyQualifiedName);

		//		var properties = TypeDescriptor.GetProperties(_user.GetType());

		//		foreach(PropertyDescriptor property in properties)
		//		{
		//			result.Add("User." + property.Name, property.GetValue(_user));
		//		}
		//	}

		//	var extendedProperties = _extendedProperties;

		//	if(extendedProperties != null && extendedProperties.Count > 0)
		//	{
		//		foreach(var extendedProperty in extendedProperties)
		//		{
		//			result.Add(EXTENDEDPROPERTIESPREFIX + extendedProperty.Key, extendedProperty.Value);
		//		}
		//	}

		//	return result;
		//}

		//public static Certification FromDictionary(IDictionary dictionary)
		//{
		//	if(dictionary == null || dictionary.Count < 1)
		//		return null;

		//	var user = new Membership.User(JF.Common.Convert.ConvertValue<int>(dictionary["User.UserId"]),
		//		JF.Common.Convert.ConvertValue<string>(dictionary["User.Name"]),
		//		JF.Common.Convert.ConvertValue<string>(dictionary["User.Namespace"]));

		//	var properties = TypeDescriptor.GetProperties(typeof(Membership.User));

		//	foreach(PropertyDescriptor property in properties)
		//	{
		//		if(property.IsReadOnly)
		//			continue;

		//		property.SetValue(user, JF.Common.Convert.ConvertValue(dictionary["User." + property.Name], property.PropertyType));
		//	}

		//	var result = new Certification((string)dictionary["CertificationId"], user,
		//		JF.Common.Convert.ConvertValue<string>(dictionary["Scene"]),
		//		JF.Common.Convert.ConvertValue<TimeSpan>(dictionary["Duration"], TimeSpan.Zero),
		//		JF.Common.Convert.ConvertValue<DateTime>(dictionary["IssuedTime"]))
		//		{
		//			Timestamp = JF.Common.Convert.ConvertValue<DateTime>(dictionary["Timestamp"]),
		//		};

		//	foreach(var key in dictionary.Keys)
		//	{
		//		if(key == null)
		//			continue;

		//		if(key.ToString().StartsWith(EXTENDEDPROPERTIESPREFIX))
		//			result.ExtendedProperties[key.ToString().Substring(EXTENDEDPROPERTIESPREFIX.Length)] = dictionary[key];
		//	}

		//	return result;
		//}

		//public static Certification FromDictionary<TValue>(IDictionary<string, TValue> dictionary)
		//{
		//	if(dictionary == null || dictionary.Count < 1)
		//		return null;

		//	Certification result;
		//	Membership.User user = null;
		//	TValue certificationId, userId, userName, scene, timestamp, issuedTime, duration, @namespace;

		//	if(dictionary.TryGetValue("User.UserId", out userId) && dictionary.TryGetValue("User.Name", out userName) && dictionary.TryGetValue("User.Namespace", out @namespace))
		//	{
		//		user = new Membership.User(JF.Common.Convert.ConvertValue<int>(userId),
		//								   JF.Common.Convert.ConvertValue<string>(userName),
		//								   JF.Common.Convert.ConvertValue<string>(@namespace));

		//		var properties = TypeDescriptor.GetProperties(typeof(Membership.User));

		//		foreach(PropertyDescriptor property in properties)
		//		{
		//			if(property.IsReadOnly)
		//				continue;

		//			property.SetValue(user, JF.Common.Convert.ConvertValue(dictionary["User." + property.Name], property.PropertyType));
		//		}
		//	}

		//	if(dictionary.TryGetValue("CertificationId", out certificationId) && user != null)
		//	{
		//		dictionary.TryGetValue("Scene", out scene);
		//		dictionary.TryGetValue("IssuedTime", out issuedTime);
		//		dictionary.TryGetValue("Duration", out duration);
		//		dictionary.TryGetValue("Timestamp", out timestamp);

		//		result = new Certification(JF.Common.Convert.ConvertValue<string>(certificationId), user,
		//									JF.Common.Convert.ConvertValue<string>(scene),
		//									JF.Common.Convert.ConvertValue<TimeSpan>(duration),
		//									JF.Common.Convert.ConvertValue<DateTime>(issuedTime))
		//									{
		//										Timestamp = JF.Common.Convert.ConvertValue<DateTime>(timestamp),
		//									};
		//	}
		//	else
		//		return null;

		//	foreach(var key in dictionary.Keys)
		//	{
		//		if(key == null)
		//			continue;

		//		if(key.ToString().StartsWith(EXTENDEDPROPERTIESPREFIX))
		//			result.ExtendedProperties[key.ToString().Substring(EXTENDEDPROPERTIESPREFIX.Length)] = dictionary[key];
		//	}

		//	return result;
		//}

		#endregion

		#region 重写方法

		public override bool Equals(object obj)
		{
			if(obj == null || obj.GetType() != this.GetType())
			{
				return false;
			}

			var other = (Credential)obj;

			return string.Equals(this.CredentialId, other.CredentialId, StringComparison.OrdinalIgnoreCase) && string.Equals(this.Scene, other.Scene, StringComparison.OrdinalIgnoreCase);
		}

		public override int GetHashCode()
		{
			return (this.CredentialId + ":" + this.Scene).ToLowerInvariant().GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("{0}:{1} {2}", this.CredentialId, this.Scene, this.User);
		}

		#endregion
	}
}