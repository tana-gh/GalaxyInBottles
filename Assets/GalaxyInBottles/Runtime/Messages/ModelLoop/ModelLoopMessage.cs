
namespace tana_gh.GalaxyInBottles
{
    [Role("Message", SceneKind.Sandbox)]
    public readonly struct ModelLoopMessage
    {
        public readonly float deltaTime;

        public ModelLoopMessage(float deltaTime)
        {
            this.deltaTime = deltaTime;
        }
    }
}
