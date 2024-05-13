using Cysharp.Threading.Tasks;
using VContainer;
using VitalRouter;

namespace tana_gh.GalaxyInBottles
{
    [Routes]
    [Role("Handler", SceneKind.Sandbox)]
    public partial class UpdateHandler
    {
        [Inject] private SandboxConfig SandboxConfig { get; set; }
        [Inject] private ICommandPublisher Publisher { get; set; }

        private float RemainingTime { get; set; } = 0.0F;

        [Route]
        private async UniTask OnUpdate(UpdateCommand msg)
        {
            var modelLoopFrequency = SandboxConfig.ModelLoopFrequency;
            var loopCount = (int)((RemainingTime + msg.DeltaTime) / modelLoopFrequency);
            RemainingTime = (RemainingTime + msg.DeltaTime) % modelLoopFrequency;

            for (var i = 0; i < loopCount; i++)
            {
                await Publisher.PublishAsync(new ModelLoopCommand(modelLoopFrequency));
            }
        }
    }
}
