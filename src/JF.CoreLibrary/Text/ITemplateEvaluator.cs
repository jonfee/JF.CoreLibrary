using System;
using System.Collections.Generic;

namespace JF.Text
{
	public interface ITemplateEvaluator
	{
		string Scheme
		{
			get;
		}

		object Evaluate(TemplateEvaluatorContext context);
	}
}