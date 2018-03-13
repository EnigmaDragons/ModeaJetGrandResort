using SpaceResortMurder.Deductions.TheMurdererWas;

namespace SpaceResortMurder.Deductions.TheCulpritsMotive
{
    public class MeleenaKilledHimBecauseHeIsEvil : Deduction
    {
        public MeleenaKilledHimBecauseHeIsEvil() : base(nameof(MeleenaWasTheCulprit)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(MeleenaWasTheCulprit));
        }
    }
}
