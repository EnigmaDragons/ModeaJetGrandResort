using SpaceResortMurder.Deductions.MeleenasAccountValidity;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.TheMurdererWas
{
    public class MeleenaWasTheCulprit : Deduction
    {
        public MeleenaWasTheCulprit() : base(nameof(MeleenaWasTheCulprit)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(MeleenaIsLying));
        }
    }
}
