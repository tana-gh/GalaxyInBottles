using System.Threading;
using Cysharp.Threading.Tasks;
using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace tana_gh.GalaxyInBottles
{
    public partial class SandboxEntryPoint : IAsyncStartable, ITickable
    {
        [Inject] private IPublisher<UpdateMessage> UpdatePub { get; set; }

        partial void Init();

        public async UniTask StartAsync(CancellationToken cancellationToken)
        {
            Init();

            await UniTask.Yield();
        }

        public void Tick()
        {
            UpdatePub.Publish(new UpdateMessage(Time.deltaTime));
        }
    }
}
