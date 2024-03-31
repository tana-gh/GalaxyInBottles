using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace tana_gh.GalaxyInBottles
{
    public static class RoleAttributeUtil
    {
        public static IEnumerable<Type> GetAllTypesWithRole(string role)
        {
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                var roleAttributes =
                    type.GetCustomAttributes(typeof(RoleAttribute), false)
                    .Cast<RoleAttribute>()
                    .Where(attr => attr.Role == role);
                foreach (var attr in roleAttributes)
                {
                    var genericParams = attr.GenericParams;
                    yield return genericParams.Length == 0 ? type : type.MakeGenericType(genericParams);
                }
            }
        }
    }
}
