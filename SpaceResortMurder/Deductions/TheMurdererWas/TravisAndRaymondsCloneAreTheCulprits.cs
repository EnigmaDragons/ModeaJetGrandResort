using SpaceResortMurder.Deductions.VictimsIdentity;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.TheMurdererWas
{
    public class TravisAndRaymondsCloneAreTheCulprits : Deduction
    {
        public TravisAndRaymondsCloneAreTheCulprits() : base(nameof(TravisAndRaymondsCloneAreTheCulprits)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(TheVictimIsRaymond)) && false;
        }
    }
}
