using Cysharp.Threading.Tasks;
using VitalRouter;

namespace tana_gh.GalaxyInBottles
{
    [Routes]
    [Role("Handler", SceneKind.Sandbox)]
    public partial class SandboxHandler
    {
        [Route]
        private async UniTask OnModelLoop(ModelLoopCommand msg)
        {
            UnityEngine.Debug.Log("ModelLoop");
            await UniTask.Yield();
        }
    }
}
