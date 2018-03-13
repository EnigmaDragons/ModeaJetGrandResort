using SpaceResortMurder.Deductions.TheMurdererWas;
using SpaceResortMurder.Deductions.VictimsIdentity;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.TheCulpritsMotive
{
    public class RevengeForHisBrothersDeath : Deduction
    {
        public RevengeForHisBrothersDeath() : base(nameof(RevengeForHisBrothersDeath)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(TravisWasTheCulprit))
                && !CurrentGameState.Instance.IsThinking(nameof(TheVictimIsRaymondsClone));
        }
    }
}
