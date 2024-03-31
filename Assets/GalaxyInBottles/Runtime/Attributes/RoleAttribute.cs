using System;

namespace tana_gh.GalaxyInBottles
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true, Inherited = false)]
    public class RoleAttribute : Attribute
    {
        public string Role { get; }
        public Type[] GenericParams { get; }

        public RoleAttribute(string role, params Type[] genericParams)
        {
            Role = role;
            GenericParams = genericParams;
        }
    }
}
