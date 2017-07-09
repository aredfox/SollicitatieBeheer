using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Beheerdersportaal.Model.Infrastructuur
{
    public class Builder<TObject, TBuilder> 
        where TBuilder : Builder<TObject, TBuilder>
        where TObject : class
    {
        private readonly IDictionary<PropertyInfo, object> _values
            = new Dictionary<PropertyInfo, object>();

        public virtual TObject Build()
        {
            var @object = Activator.CreateInstance(typeof(TObject), nonPublic: true) as TObject;

            foreach(var keyValuePair in _values) {
                var propertyInfo = keyValuePair.Key;
                var value = keyValuePair.Value;

                propertyInfo.SetValue(@object, value);
            }

            return @object;
        }

        public virtual TBuilder With<TProperty>(
            Expression<Func<TObject, TProperty>> propertySelectorExpression, TProperty value)
        {
            var propertyInfo = ObjectHelper.SelectProperty(propertySelectorExpression);
            _values[propertyInfo] = value;

            return this as TBuilder;
        }
    }
}
