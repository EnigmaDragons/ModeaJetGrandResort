using SpaceResortMurder.Deductions.TheMurdererWas;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.TheCulpritsMotive
{
    public class RaymondsCloneWasDesignedToKillForRevenge : Deduction
    {
        public RaymondsCloneWasDesignedToKillForRevenge() : base(nameof(RaymondsCloneWasDesignedToKillForRevenge)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(TravisAndRaymondsCloneAreTheCulprits));
        }
    }
}
