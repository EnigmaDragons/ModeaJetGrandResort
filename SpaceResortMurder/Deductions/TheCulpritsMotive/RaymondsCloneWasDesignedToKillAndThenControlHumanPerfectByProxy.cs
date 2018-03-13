using SpaceResortMurder.Deductions.TheMurdererWas;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.TheCulpritsMotive
{
    public class RaymondsCloneWasDesignedToKillAndThenControlHumanPerfectByProxy : Deduction
    {
        public RaymondsCloneWasDesignedToKillAndThenControlHumanPerfectByProxy() : base(nameof(RaymondsCloneWasDesignedToKillAndThenControlHumanPerfectByProxy)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(TravisAndRaymondsCloneAreTheCulprits));
        }
    }
}
