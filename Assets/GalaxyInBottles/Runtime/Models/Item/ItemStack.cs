using System;

namespace tana_gh.GalaxyInBottles
{
    [Serializable]
    public class ItemStack
    {
        public int id;
        public int count;
        public int maxCount;
        public ItemSetting setting;
    }
}
