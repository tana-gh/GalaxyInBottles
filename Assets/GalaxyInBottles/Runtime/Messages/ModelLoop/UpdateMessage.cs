
namespace tana_gh.GalaxyInBottles
{
    [Role("Message", SceneKind.Sandbox)]
    public readonly struct UpdateMessage
    {
        public float DeltaTime { get; }

        public UpdateMessage(float deltaTime)
        {
            DeltaTime = deltaTime;
        }
    }
}
