using System;
using System.Collections;
using System.Collections.Generic;

namespace JF.Services
{
	public interface IServiceStorage : IEnumerable<ServiceEntry>
	{
		IMatcher Matcher
		{
			get;
			set;
		}

		void Clear();

		void Add(ServiceEntry entry);

		ServiceEntry Remove(string name);

		ServiceEntry Get(string name);

		ServiceEntry Get(Type type, object parameter = null);

		IEnumerable<ServiceEntry> GetAll(Type type, object parameter = null);
	}
}