using SpaceResortMurder.Clues.MeleenasSpaceCraft;
using SpaceResortMurder.Deductions.TheMurdererWas;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.TheCulpritsMotive
{
    public class MeleenaKilledHimBecauseHeIsEvil : Deduction
    {
        public MeleenaKilledHimBecauseHeIsEvil() : base(nameof(MeleenaKilledHimBecauseHeIsEvil)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(MeleenaWasTheCulprit)) && CurrentGameState.IsThinking(nameof(UnencryptedDataDrive));
        }
    }
}
