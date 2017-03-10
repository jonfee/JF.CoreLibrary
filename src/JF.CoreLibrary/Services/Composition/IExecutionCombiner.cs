using System;
using System.Collections.Generic;

namespace JF.Services.Composition
{
	public interface IExecutionCombiner
	{
		object Combine(IEnumerable<IExecutionPipelineContext> contexts);
	}
}