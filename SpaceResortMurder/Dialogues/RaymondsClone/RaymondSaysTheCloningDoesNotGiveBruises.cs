using SpaceResortMurder.Dialogues.Travis;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.RaymondsClone
{
    public class RaymondSaysTheCloningDoesNotGiveBruises : Dialogue
    {
        public RaymondSaysTheCloningDoesNotGiveBruises() : base(nameof(RaymondSaysTheCloningDoesNotGiveBruises)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(MatterRemovalBruises));
        }
    }
}
