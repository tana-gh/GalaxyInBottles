
namespace tana_gh.GalaxyInBottles
{
    [Role("Message", SceneKind.Sandbox)]
    public readonly struct ModelLoopMessage
    {
        public float DeltaTime { get; }

        public ModelLoopMessage(float deltaTime)
        {
            DeltaTime = deltaTime;
        }
    }
}
