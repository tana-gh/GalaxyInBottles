using VitalRouter;

namespace tana_gh.GalaxyInBottles
{
    [Role("Command", SceneKind.Sandbox)]
    public readonly struct ModelLoopCommand : ICommand
    {
        public float DeltaTime { get; }

        public ModelLoopCommand(float deltaTime)
        {
            DeltaTime = deltaTime;
        }
    }
}
