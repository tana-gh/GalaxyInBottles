using System;

namespace tana_gh.GalaxyInBottles
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true, Inherited = false)]
    public abstract class TypeAttribute : Attribute
    {
        public Type[] GenericParams { get; }
        public string AdditionalData { get; }

        public TypeAttribute(Type[] genericParams, string additionalData = null)
        {
            GenericParams = genericParams;
            AdditionalData = additionalData;
        }
    }
}
