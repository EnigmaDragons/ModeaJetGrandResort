using SpaceResortMurder.Dialogues.RaymondsClone;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Warren
{
    public class IsTheSearchOrderReady : Dialogue
    {
        public IsTheSearchOrderReady() : base(nameof(IsTheSearchOrderReady)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(FoundYouRaymondsClone));
        }
    }
}
