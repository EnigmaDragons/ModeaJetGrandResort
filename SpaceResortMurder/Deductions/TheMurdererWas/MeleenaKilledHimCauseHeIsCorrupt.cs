using SpaceResortMurder.Deductions.MeleenasAccountValidity;

namespace SpaceResortMurder.Deductions.TheMurdererWas
{
    public class MeleenaKilledHimCauseHeIsCorrupt : Deduction
    {
        public MeleenaKilledHimCauseHeIsCorrupt() : base(nameof(MeleenaKilledHimCauseHeIsCorrupt)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(MeleenaIsLying));
        }
    }
}
