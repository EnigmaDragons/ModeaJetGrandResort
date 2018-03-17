using SpaceResortMurder.Deductions.TheMurdererWas;
using SpaceResortMurder.Dialogues.Travis;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.TheCulpritsMotive
{
    public class RaymondsCloneWasDesignedToKillForRevenge : Deduction
    {
        public RaymondsCloneWasDesignedToKillForRevenge() : base(nameof(RaymondsCloneWasDesignedToKillForRevenge)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(TravisAndRaymondsCloneAreTheCulprits)) && CurrentGameState.IsThinking(nameof(YourBrotherWasKilled));
        }
    }
}
