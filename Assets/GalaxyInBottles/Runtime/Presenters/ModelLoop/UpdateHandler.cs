using System;
using MessagePipe;
using VContainer;

namespace tana_gh.GalaxyInBottles
{
    [Role("Handler", SceneKind.Sandbox)]
    public class UpdateHandler : IDisposable
    {
        [Inject] private SandboxConfig SandboxConfig { get; set; }
        [Inject] private ISubscriber<UpdateMessage> UpdateSub { get; set; }
        [Inject] private IPublisher<ModelLoopMessage> ModelLoopPub { get; set; }

        private float RemainingTime { get; set; } = 0.0F;
        private DisposableBagBuilder Disposables { get; } = DisposableBag.CreateBuilder();
        private bool Disposed { get; set; } = false;

        public void Init()
        {
            UpdateSub.Subscribe(OnUpdate).AddTo(Disposables);
        }

        private void OnUpdate(UpdateMessage msg)
        {
            var modelLoopFrequency = SandboxConfig.ModelLoopFrequency;
            var loopCount = (int)((RemainingTime + msg.DeltaTime) / modelLoopFrequency);
            RemainingTime = (RemainingTime + msg.DeltaTime) % modelLoopFrequency;

            for (var i = 0; i < loopCount; i++)
            {
                ModelLoopPub.Publish(new ModelLoopMessage(modelLoopFrequency));
            }
        }

        public void Dispose()
        {
            if (!Disposed)
            {
                Disposables.Build().Dispose();
                Disposed = true;
            }
        }
    }
}
