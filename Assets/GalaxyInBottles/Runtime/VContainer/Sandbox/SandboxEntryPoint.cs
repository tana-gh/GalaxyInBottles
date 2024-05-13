using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using VitalRouter;

namespace tana_gh.GalaxyInBottles
{
    public partial class SandboxEntryPoint : IAsyncStartable, ITickable
    {
        [Inject] private ICommandPublisher Publisher { get; set; }

        partial void Init();

        public async UniTask StartAsync(CancellationToken cancellationToken)
        {
            Init();

            await UniTask.Yield();
        }

        public void Tick()
        {
            Publisher.PublishAsync(new UpdateCommand(Time.deltaTime)).Forget();
        }
    }
}
