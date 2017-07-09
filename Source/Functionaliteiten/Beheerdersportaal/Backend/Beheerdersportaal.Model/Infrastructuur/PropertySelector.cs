using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Beheerdersportaal.Model.Infrastructuur
{
    public sealed class ObjectHelper
    {
        public static PropertyInfo SelectProperty<TObject, TProperty>(
            Expression<Func<TObject, TProperty>> propertySelectorExpression)
        {
            var body = propertySelectorExpression as MemberExpression;
            if(body == null)
            {
                var unaryExpression = propertySelectorExpression as UnaryExpression;
                body = unaryExpression.Operand as MemberExpression;
            }

            return body.Member as PropertyInfo;
        }
    }
}
