using SpaceResortMurder.Dialogues.RaymondsClone;
using SpaceResortMurder.Dialogues.Warren;
using SpaceResortMurder.State;

namespace SpaceResortMurder.ObjectivesX
{
    public class CheckWithWarrenForASearchOrder : Objective
    {
        public CheckWithWarrenForASearchOrder() : base(nameof(CheckWithWarrenForASearchOrder)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(FoundYouRaymondsClone))
                && CurrentGameState.IsThinking(nameof(NeedASearchOrder))
                && !CurrentGameState.IsThinking(nameof(IsTheSearchOrderReady));
        }
    }
}
