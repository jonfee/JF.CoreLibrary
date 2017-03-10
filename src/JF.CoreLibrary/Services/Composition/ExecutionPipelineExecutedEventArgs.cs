using System;
using System.Collections.Generic;

namespace JF.Services.Composition
{
	public class ExecutionPipelineExecutedEventArgs : ExecutionEventArgs<IExecutionPipelineContext>
	{
		public ExecutionPipelineExecutedEventArgs(IExecutionPipelineContext context) : base(context)
		{
		}
	}
}