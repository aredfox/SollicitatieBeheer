using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sollicitatiebeheer.Data.EFCore.Infrastructuur
{
    internal static class PropertyInfoExtension
    {
        public static IEnumerable<KeyValuePair<Type, PropertyInfo>> WhereIsOfType(
            this IEnumerable<PropertyInfo> propertyInfos, Type type)
        {            
            var isGenericType = type.IsGenericType;

            return propertyInfos
                .Select(propertyInfo => new { Type = propertyInfo.PropertyType, PropertyInfo = propertyInfo })
                .Where(x =>
                {
                    return
                        isGenericType || x.Type.IsGenericType
                        && type.IsAssignableFrom(x.Type);
                })
                .Select(x => new KeyValuePair<Type, PropertyInfo>(x.Type, x.PropertyInfo));
        }
    }
}
