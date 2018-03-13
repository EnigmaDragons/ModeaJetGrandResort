using SpaceResortMurder.Deductions.TheMurdererWas;

namespace SpaceResortMurder.Deductions.TheCulpritsMotive
{
    public class RaymondsCloneWasDesignedToKillAndThenControlHumanPerfectByProxy : Deduction
    {
        public RaymondsCloneWasDesignedToKillAndThenControlHumanPerfectByProxy() : base(nameof(RaymondsCloneWasDesignedToKillAndThenControlHumanPerfectByProxy)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(TravisAndRaymondsCloneAreTheCulprits));
        }
    }
}
