using SpaceResortMurder.Deductions.TheMurdererWas;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.TheCulpritsMotive
{
    public class MeleenaKilledHimBecauseHeIsEvil : Deduction
    {
        public MeleenaKilledHimBecauseHeIsEvil() : base(nameof(MeleenaWasTheCulprit)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(MeleenaWasTheCulprit));
        }
    }
}
