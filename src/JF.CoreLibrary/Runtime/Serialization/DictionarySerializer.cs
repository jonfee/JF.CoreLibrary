﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using JF.Common;

namespace JF.Runtime.Serialization
{
	public class DictionarySerializer : IDictionarySerializer
	{
		#region 单例字段

		public static readonly DictionarySerializer Default = new DictionarySerializer();

		#endregion

		public IDictionary Serialize(object graph)
		{
			var dictionary = new Dictionary<string, object>();
			this.Serialize(graph, dictionary);
			return dictionary;
		}

		public void Serialize(object graph, IDictionary dictionary)
		{
			if(graph == null)
			{
				return;
			}

			if(dictionary == null)
			{
				throw new ArgumentNullException("dictionary");
			}

			dictionary.Add("@type", graph.GetType().AssemblyQualifiedName);

			var properties = graph.GetType().GetProperties();

			foreach(var property in properties)
			{
				if(!property.CanRead)
				{
					continue;
				}

				if(TypeExtensions.IsScalarType(property.PropertyType))
				{
					dictionary.Add(property.Name.ToLowerInvariant(), property.GetValue(graph));
				}
			}
		}

		public object Deserialize(IDictionary dictionary)
		{
			return this.Deserialize(dictionary, null);
		}

		public object Deserialize(IDictionary dictionary, Type type)
		{
			return this.Deserialize(dictionary, type, null);
		}

		public object Deserialize(IDictionary dictionary, Type type, Action<JF.Common.Convert.ObjectResolvingContext> resolve)
		{
			if(type == null)
			{
				throw new ArgumentNullException("type");
			}

			return this.Deserialize<object>(dictionary, () => Activator.CreateInstance(type), resolve);
		}

		public T Deserialize<T>(IDictionary dictionary)
		{
			return (T)this.Deserialize(dictionary, typeof(T));
		}

		public T Deserialize<T>(IDictionary dictionary, Func<T> creator, Action<JF.Common.Convert.ObjectResolvingContext> resolve)
		{
			if(dictionary == null)
			{
				return default(T);
			}

			var result = creator != null ? creator() : Activator.CreateInstance<T>();

			if(resolve == null)
			{
				resolve = ctx =>
				{
					if(ctx.Direction == JF.Common.Convert.ObjectResolvingDirection.Get)
					{
						ctx.Value = ctx.GetMemberValue();

						if(ctx.Value == null)
						{
							ctx.Value = Activator.CreateInstance(ctx.MemberType);

							switch(ctx.Member.MemberType)
							{
								case MemberTypes.Field:
									((FieldInfo)ctx.Member).SetValue(ctx.Container, ctx.Value);
									break;
								case MemberTypes.Property:
									((PropertyInfo)ctx.Member).SetValue(ctx.Container, ctx.Value);
									break;
							}
						}
					}
				};
			}

			foreach(DictionaryEntry entry in dictionary)
			{
				if(entry.Key == null)
				{
					continue;
				}

				JF.Common.Convert.SetValue(result, entry.Key.ToString(), entry.Value, resolve);
			}

			return result;
		}
	}
}