using SpaceResortMurder.Dialogues.Travis;
using SpaceResortMurder.State;

namespace SpaceResortMurder.ObjectivesX
{
    public class FindRaymondsClone : Objective
    {
        public FindRaymondsClone() : base(nameof(FindRaymondsClone)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(TravissAccount));
        }
    }
}
