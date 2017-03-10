using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JF.Services
{
	public class ServiceNotFoundException : ApplicationException
	{
		#region 构造方法

		public ServiceNotFoundException()
		{
		}

		public ServiceNotFoundException(string message) : base(message)
		{
		}

		public ServiceNotFoundException(string message, Exception innerException) : base(message, innerException)
		{
		}

		#endregion
	}
}