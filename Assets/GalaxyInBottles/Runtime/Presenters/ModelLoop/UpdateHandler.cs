using System;
using MessagePipe;
using VContainer;

namespace tana_gh.GalaxyInBottles
{
    [Role("Handler")]
    public class UpdateHandler : IDisposable
    {
        [Inject] private readonly MainConfig _mainConfig;
        [Inject] private readonly ISubscriber<UpdateMessage> _updateSub;
        [Inject] private readonly IPublisher<ModelLoopMessage> _modelLoopPub;

        private float _remainingTime = 0.0F;
        private readonly DisposableBagBuilder _disposables = DisposableBag.CreateBuilder();
        private bool _disposed = false;

        public void Init()
        {
            _updateSub.Subscribe(OnUpdate).AddTo(_disposables);
        }

        private void OnUpdate(UpdateMessage msg)
        {
            var ModelLoopFrequency = _mainConfig.ModelLoopFrequency;
            var loopCount = (int)((_remainingTime + msg.deltaTime) / ModelLoopFrequency);
            _remainingTime = (_remainingTime + msg.deltaTime) % ModelLoopFrequency;

            for (var i = 0; i < loopCount; i++)
            {
                _modelLoopPub.Publish(new ModelLoopMessage(ModelLoopFrequency));
            }
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
