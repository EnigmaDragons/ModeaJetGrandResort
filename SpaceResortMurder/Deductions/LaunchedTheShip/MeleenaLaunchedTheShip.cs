using SpaceResortMurder.CharactersX;
using SpaceResortMurder.Dialogues.Meleena;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.LaunchedTheShip
{
    public class MeleenaLaunchedTheShip : Deduction
    {
        public MeleenaLaunchedTheShip() : base(nameof(MeleenaLaunchedTheShip)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(WhoAreYou)) || CurrentGameState.IsThinking(nameof(HackerMeleena));
        }
    }
}
