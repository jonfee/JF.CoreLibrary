using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace JF.Common
{
	internal static class ExpressionUtility
	{
		internal static string GetMemberName(Expression expression)
		{
			return GetMember(expression).Item1;
		}

		internal static Tuple<string, Type> GetMember(Expression expression)
		{
			var tuple = ResolveMemberExpression(expression, new Stack<MemberInfo>());

			if(tuple == null)
			{
				throw new ArgumentException("Invalid member expression.");
			}

			switch(tuple.Item2.MemberType)
			{
				case MemberTypes.Property:
					return new Tuple<string, Type>(tuple.Item1, ((PropertyInfo)tuple.Item2).PropertyType);
				case MemberTypes.Field:
					return new Tuple<string, Type>(tuple.Item1, ((FieldInfo)tuple.Item2).FieldType);
				default:
					throw new InvalidOperationException("Invalid expression.");
			}
		}

		private static Tuple<string, MemberInfo> ResolveMemberExpression(Expression expression, Stack<MemberInfo> stack)
		{
			if(expression.NodeType == ExpressionType.Lambda)
			{
				return ResolveMemberExpression(((LambdaExpression)expression).Body, stack);
			}

			switch(expression.NodeType)
			{
				case ExpressionType.MemberAccess:
					stack.Push(((MemberExpression)expression).Member);

					if(((MemberExpression)expression).Expression != null)
					{
						return ResolveMemberExpression(((MemberExpression)expression).Expression, stack);
					}

					break;
				case ExpressionType.Convert:
				case ExpressionType.ConvertChecked:
					return ResolveMemberExpression(((UnaryExpression)expression).Operand, stack);
			}

			if(stack == null || stack.Count == 0)
			{
				return null;
			}

			var path = string.Empty;
			var type = typeof(object);
			MemberInfo member = null;

			while(stack.Count > 0)
			{
				member = stack.Pop();

				if(path.Length > 0)
				{
					path += ".";
				}

				path += member.Name;
			}

			return new Tuple<string, MemberInfo>(path, member);
		}
	}
}