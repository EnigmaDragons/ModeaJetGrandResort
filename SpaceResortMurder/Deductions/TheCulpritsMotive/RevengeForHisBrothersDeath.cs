using SpaceResortMurder.Deductions.TheMurdererWas;
using SpaceResortMurder.Deductions.VictimsIdentity;

namespace SpaceResortMurder.Deductions.TheCulpritsMotive
{
    public class RevengeForHisBrothersDeath : Deduction
    {
        public RevengeForHisBrothersDeath() : base(nameof(RevengeForHisBrothersDeath)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(TravisWasTheCulprit))
                && !GameState.Instance.IsThinking(nameof(TheVictimIsRaymondsClone));
        }
    }
}
