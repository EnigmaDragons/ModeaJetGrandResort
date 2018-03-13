using SpaceResortMurder.Deductions.TheMurdererWas;
using SpaceResortMurder.Deductions.VictimsIdentity;

namespace SpaceResortMurder.Deductions.TheCulpritsMotive
{
    public class RaymondsCloneWasDesignedToKillForRevenge : Deduction
    {
        public RaymondsCloneWasDesignedToKillForRevenge() : base(nameof(RaymondsCloneWasDesignedToKillForRevenge)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(TravisAndRaymondsCloneAreTheCulprits))
                   && GameState.Instance.IsThinking(nameof(TheVictimIsRaymond));
        }
    }
}
