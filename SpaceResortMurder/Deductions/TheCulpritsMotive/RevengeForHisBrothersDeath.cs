using SpaceResortMurder.Deductions.TheMurdererWas;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.TheCulpritsMotive
{
    public class RevengeForHisBrothersDeath : Deduction
    {
        public RevengeForHisBrothersDeath() : base(nameof(RevengeForHisBrothersDeath)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(TravisWasTheCulprit));
        }
    }
}
