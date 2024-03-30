
namespace tana_gh.GalaxyInBottles
{
    [Message]
    public readonly struct UpdateMessage
    {
        public readonly float deltaTime;

        public UpdateMessage(float deltaTime)
        {
            this.deltaTime = deltaTime;
        }
    }
}
