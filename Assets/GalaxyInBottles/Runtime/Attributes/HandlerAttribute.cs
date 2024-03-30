using System;

namespace tana_gh.GalaxyInBottles
{
    public class HandlerAttribute : TypeAttribute
    {
        public HandlerAttribute(params Type[] genericParams)
            : base(genericParams)
        {
        }
    }
}
