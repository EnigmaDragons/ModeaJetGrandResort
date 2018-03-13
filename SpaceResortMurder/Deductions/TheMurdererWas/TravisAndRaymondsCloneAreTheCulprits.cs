using SpaceResortMurder.Deductions.VictimsIdentity;

namespace SpaceResortMurder.Deductions.TheMurdererWas
{
    public class TravisAndRaymondsCloneAreTheCulprits : Deduction
    {
        public TravisAndRaymondsCloneAreTheCulprits() : base(nameof(TravisAndRaymondsCloneAreTheCulprits)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(TheVictimIsRaymond)) && false;
        }
    }
}
