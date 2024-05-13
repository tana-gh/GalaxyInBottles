using VitalRouter;

namespace tana_gh.GalaxyInBottles
{
    [Role("Command", SceneKind.Sandbox)]
    public readonly struct UpdateCommand : ICommand
    {
        public float DeltaTime { get; }

        public UpdateCommand(float deltaTime)
        {
            DeltaTime = deltaTime;
        }
    }
}
