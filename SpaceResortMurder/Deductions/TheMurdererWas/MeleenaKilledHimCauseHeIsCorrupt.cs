using SpaceResortMurder.Deductions.MeleenasAccountValidity;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.TheMurdererWas
{
    public class MeleenaKilledHimCauseHeIsCorrupt : Deduction
    {
        public MeleenaKilledHimCauseHeIsCorrupt() : base(nameof(MeleenaKilledHimCauseHeIsCorrupt)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(MeleenaIsLying));
        }
    }
}
