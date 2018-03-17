using SpaceResortMurder.CharactersX;
using SpaceResortMurder.Dialogues.Meleena;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.TheMurdererWas
{
    public class MeleenaWasTheCulprit : Deduction
    {
        public MeleenaWasTheCulprit() : base(nameof(MeleenaWasTheCulprit)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(WhoAreYou)) || CurrentGameState.IsThinking(nameof(HackerMeleena));
        }
    }
}
