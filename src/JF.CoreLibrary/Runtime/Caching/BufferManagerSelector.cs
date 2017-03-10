using System;
using System.IO;

namespace JF.Runtime.Caching
{
	public class BufferManagerSelector : IBufferManagerSelector
	{
		public IBufferManager GetBufferManager(long size)
		{
			return BufferManager.Default;
		}
	}
}