using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq.Expressions;
using System;
using System.Reflection;

public static class ExpressionExtensions
{
	public static PropertyInfo GetPropertyFromExpression<T>(this Expression<Func<T, object>> GetPropertyLambda)
    {
        MemberExpression Exp = null;

        if (GetPropertyLambda.Body is UnaryExpression)
        {
            var UnExp = (UnaryExpression)GetPropertyLambda.Body;
            if (UnExp.Operand is MemberExpression)
            {
                Exp = (MemberExpression)UnExp.Operand;
            }
            else
			{
                throw new ArgumentException();
			}
        }
        else if (GetPropertyLambda.Body is MemberExpression)
        {
            Exp = (MemberExpression)GetPropertyLambda.Body;
        }
        else
        {
            throw new ArgumentException();
        }

        return (PropertyInfo)Exp.Member;
    }	 
}
