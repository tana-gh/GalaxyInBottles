using System;
using MessagePipe;
using VContainer;

namespace tana_gh.GalaxyInBottles
{
    [Role("Handler", SceneKind.Sandbox)]
    public class SandboxHandler : IDisposable
    {
        [Inject] private ISubscriber<ModelLoopMessage> ModelLoopSub { get; set; }

        private DisposableBagBuilder Disposables { get; } = DisposableBag.CreateBuilder();
        private bool Disposed { get; set; } = false;

        public void Init()
        {
            ModelLoopSub.Subscribe(OnModelLoop).AddTo(Disposables);
        }

        private void OnModelLoop(ModelLoopMessage msg)
        {
            UnityEngine.Debug.Log("ModelLoop");
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
