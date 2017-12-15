using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq.Expressions;
using System.Reflection;

public class PropertyRestorer<TObj> : IDisposable
{
	private TObj obj;

	private PropertyInfo property;

	private object originalValue;

    public PropertyRestorer(TObj obj, Expression<Func<TObj, object>> propertySelector)
    {
        this.obj = obj;
		property = propertySelector.GetPropertyFromExpression();
        originalValue = property.GetValue(obj, null);
    }

    public void Dispose()
    {
        property.SetValue(obj, originalValue, null);
    }
}
