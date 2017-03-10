using System;
using System.IO;
using System.Collections.Generic;
using JF.Services;
using JF.Services.Composition;

namespace JF.Communication
{
	internal static class Utility
	{
		#region 公共方法

		public static void ProcessReceive(IExecutor executor, ReceivedEventArgs args)
		{
			if(args == null)
			{
				throw new ArgumentNullException("args");
			}

			//如果执行器参数为空，不抛出异常，直接退出
			if(executor == null)
			{
				return;
			}

			//通过执行器执行当前请求
			executor.Execute(args);
		}

		#endregion

		#region 嵌套子类

		public class CommunicationExecutor : JF.Services.Composition.Executor
		{
			internal CommunicationExecutor(object host) : base(host)
			{
			}

			protected override IExecutionContext CreateContext(object parameter)
			{
				var args = parameter as ReceivedEventArgs;

				if(args != null)
				{
					return new ChannelContext(this, args.ReceivedObject, args.Channel);
				}

				return base.CreateContext(parameter);
			}

			protected override ExecutionPipelineContext CreatePipelineContext(IExecutionContext context, ExecutionPipeline pipeline, object parameter)
			{
				var channelContext = context as IChannelContext;

				if(channelContext != null)
				{
					return new ChannelPipelineContext(context, pipeline, parameter, channelContext.Channel);
				}

				return base.CreatePipelineContext(context, pipeline, parameter);
			}
		}

		#endregion
	}
}