using SpaceResortMurder.Deductions.TheMurdererWas;

namespace SpaceResortMurder.Deductions.TheCulpritsMotive
{
    public class MeleenaGotCaught : Deduction
    {
        public MeleenaGotCaught() : base(nameof(MeleenaGotCaught)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(MeleenaWasTheCulprit));
        }
    }
}
