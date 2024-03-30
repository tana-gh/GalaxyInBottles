using System;
using MessagePipe;
using VContainer;

namespace tana_gh.GalaxyInBottles
{
    [Handler]
    public class GameHandler : IDisposable
    {
        [Inject] private readonly ISubscriber<ModelLoopMessage> _modelLoopSub;

        private readonly DisposableBagBuilder _disposables = DisposableBag.CreateBuilder();
        private bool _disposed = false;

        public void Init()
        {
            _modelLoopSub.Subscribe(OnModelLoop).AddTo(_disposables);
        }

        private void OnModelLoop(ModelLoopMessage msg)
        {
            UnityEngine.Debug.Log("ModelLoop");
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposables.Build().Dispose();
                _disposed = true;
            }
        }
    }
}
