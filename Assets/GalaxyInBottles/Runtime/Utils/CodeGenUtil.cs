using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace tana_gh.GalaxyInBottles
{
    public static class CodeGenUtil
    {
        public static string GetTypeName(this Type type)
        {
            return
                (type.DeclaringType == null ? "" : $"{GetTypeName(type.DeclaringType)}.") +
                GetName(type) +
                (type.IsGenericType ? $"<{string.Join(", ", type.GenericTypeArguments.Select(t => t.GetTypeName()))}>" : "");
        }

        public static string GetVarName(this Type type)
        {
            var name = GetName(type);
            return $"_{char.ToLower(name[0])}{name[1..]}";
        }

        private static string GetName(Type type)
        {
            return Regex.Replace(type.Name, @"(.+\+)*(.+?)(`.+)?", "$2");
        }

        public static string ToLines(this IEnumerable<string> sources, int indent)
        {
            return string.Join("", sources.Select(source => $"{Environment.NewLine}{new string(' ', indent)}{source}"));
        }
    }
}
