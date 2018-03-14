using SpaceResortMurder.Deductions.TheMurdererWas;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.TheCulpritsMotive
{
    public class MeleenaGotCaught : Deduction
    {
        public MeleenaGotCaught() : base(nameof(MeleenaGotCaught)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(MeleenaWasTheCulprit));
        }
    }
}
