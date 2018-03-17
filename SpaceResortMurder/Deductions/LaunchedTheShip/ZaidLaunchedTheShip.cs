using SpaceResortMurder.CharactersX;
using SpaceResortMurder.Dialogues.Zaid;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.LaunchedTheShip
{
    public class ZaidLaunchedTheShip : Deduction
    {
        public ZaidLaunchedTheShip() : base(nameof(ZaidLaunchedTheShip)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(ResortManagerZaid)) || CurrentGameState.IsThinking(nameof(WhoAreYouZaid));
        }
    }
}
