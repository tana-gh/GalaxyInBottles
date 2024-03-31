
namespace tana_gh.GalaxyInBottles
{
    [Role("Message")]
    public readonly struct ModelLoopMessage
    {
        public readonly float deltaTime;

        public ModelLoopMessage(float deltaTime)
        {
            this.deltaTime = deltaTime;
        }
    }
}
