using SpaceResortMurder.Deductions.TheMurdererWas;
using SpaceResortMurder.Deductions.VictimsIdentity;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.TheCulpritsMotive
{
    public class RaymondsCloneWasDesignedToKillForRevenge : Deduction
    {
        public RaymondsCloneWasDesignedToKillForRevenge() : base(nameof(RaymondsCloneWasDesignedToKillForRevenge)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(TravisAndRaymondsCloneAreTheCulprits))
                   && CurrentGameState.Instance.IsThinking(nameof(TheVictimIsRaymond));
        }
    }
}
