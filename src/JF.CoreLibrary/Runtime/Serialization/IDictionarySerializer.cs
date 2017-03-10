using System;
using System.Collections;
using System.Collections.Generic;

namespace JF.Runtime.Serialization
{
	public interface IDictionarySerializer
	{
		IDictionary Serialize(object graph);

		void Serialize(object graph, IDictionary dictionary);

		object Deserialize(IDictionary dictionary);

		object Deserialize(IDictionary dictionary, Type type);
	}
}