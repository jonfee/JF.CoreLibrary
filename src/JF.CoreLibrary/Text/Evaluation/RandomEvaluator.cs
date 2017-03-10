using System;
using System.Collections.Generic;

namespace JF.Text.Evaluation
{
	public class RandomEvaluator : TemplateEvaluatorBase
	{
		#region 构造方法

		public RandomEvaluator() : base("random")
		{
		}

		public RandomEvaluator(string scheme) : base(scheme)
		{
		}

		#endregion

		#region 重写方法

		public override object Evaluate(TemplateEvaluatorContext context)
		{
			if(string.IsNullOrWhiteSpace(context.Text))
			{
				return this.GetDefaultRandom();
			}

			switch(context.Text.ToLowerInvariant())
			{
				case "byte":
					return JF.Common.RandomGenerator.Generate(1)[0].ToString();
				case "short":
				case "int16":
					return ((ushort)JF.Common.RandomGenerator.GenerateInt32()).ToString();
				case "int":
				case "int32":
					return ((uint)JF.Common.RandomGenerator.GenerateInt32()).ToString();
				case "long":
				case "int64":
					return ((ulong)JF.Common.RandomGenerator.GenerateInt64()).ToString();
				case "guid":
					return Guid.NewGuid().ToString("n");
			}

			int length;

			if(JF.Common.Convert.TryConvertValue<int>(context.Text, out length))
			{
				return JF.Common.RandomGenerator.GenerateString(Math.Max(length, 1));
			}

			return this.GetDefaultRandom();
		}

		#endregion

		#region 私有方法

		private string GetDefaultRandom()
		{
			return JF.Common.RandomGenerator.GenerateString(6);
		}

		#endregion
	}
}