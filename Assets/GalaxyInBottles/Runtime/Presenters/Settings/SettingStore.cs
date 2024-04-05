using System.Collections.Generic;
using System.Linq;

namespace tana_gh.GalaxyInBottles
{
    [Role("SettingStore", SceneKind.Root, typeof(ItemSetting))]
    public class SettingStore<TSetting>
        where TSetting : ISetting
    {
        public Dictionary<string, TSetting> Settings { get; private set; }

        public void Init(IEnumerable<TSetting> settings)
        {
            Settings = settings.ToDictionary(x => x.Kind, x => x);
        }
    }
}
