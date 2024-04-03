using UnityEngine;

namespace tana_gh.GalaxyInBottles
{
    [CreateAssetMenu(menuName = "ScriptableObjects/SandboxConfig")]
    [Role("Setting")]
    public class SandboxConfig : ScriptableObject
    {
        [SerializeField] private float _modelLoopFrequency = 1.0F / 128.0F;
        public float ModelLoopFrequency => _modelLoopFrequency;
    }
}
