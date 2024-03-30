
namespace tana_gh.GalaxyInBottles
{
    [Message]
    public readonly struct ModelLoopMessage
    {
        public readonly float deltaTime;

        public ModelLoopMessage(float deltaTime)
        {
            this.deltaTime = deltaTime;
        }
    }
}
