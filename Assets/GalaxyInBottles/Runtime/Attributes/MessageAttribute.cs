using System;

namespace tana_gh.GalaxyInBottles
{
    public class MessageAttribute : TypeAttribute
    {
        public MessageAttribute(params Type[] genericParams)
            : base(genericParams)
        {
        }
    }
}
