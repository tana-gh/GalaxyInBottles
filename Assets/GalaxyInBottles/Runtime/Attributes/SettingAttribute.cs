using System;

namespace tana_gh.GalaxyInBottles
{
    public class SettingAttribute : TypeAttribute
    {
        public SettingAttribute(params Type[] genericParams)
            : base(genericParams)
        {
        }
    }
}
