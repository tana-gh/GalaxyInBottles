
namespace tana_gh.GalaxyInBottles
{
    [Role("Message", SceneKind.Sandbox)]
    public readonly struct UpdateMessage
    {
        public readonly float deltaTime;

        public UpdateMessage(float deltaTime)
        {
            this.deltaTime = deltaTime;
        }
    }
}
