using UnityEngine;

namespace tana_gh.GalaxyInBottles
{
    [CreateAssetMenu(menuName = "ScriptableObjects/ItemSetting")]
    [Role("SettingArray", SceneKind.Root)]
    public class ItemSetting : ScriptableObject, ISetting
    {
        [SerializeField] private string _kind;
        [SerializeField] private string _name;
        [SerializeField] private int _stackCount;
        public string Kind => _kind;
        public string Name => _name;
        public int StackCount => _stackCount;
    }
}
