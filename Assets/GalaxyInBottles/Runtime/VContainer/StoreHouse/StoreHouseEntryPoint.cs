using System.Threading;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace tana_gh.GalaxyInBottles
{
    public partial class StoreHouseEntryPoint : IAsyncStartable
    {
        partial void Init();

        public async UniTask StartAsync(CancellationToken cancellationToken)
        {
            Init();

            await UniTask.Yield();
        }
    }
}
