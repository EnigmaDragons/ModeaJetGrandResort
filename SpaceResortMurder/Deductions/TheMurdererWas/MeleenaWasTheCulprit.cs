using SpaceResortMurder.Deductions.MeleenasAccountValidity;

namespace SpaceResortMurder.Deductions.TheMurdererWas
{
    public class MeleenaWasTheCulprit : Deduction
    {
        public MeleenaWasTheCulprit() : base(nameof(MeleenaWasTheCulprit)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(MeleenaIsLying));
        }
    }
}
