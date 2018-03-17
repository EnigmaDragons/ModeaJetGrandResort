using SpaceResortMurder.Deductions.LaunchedTheShip;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Zaid
{
    public class ZaidLaunchedTheShipToGetHisPad : Dialogue
    {
        public ZaidLaunchedTheShipToGetHisPad() : base(nameof(ZaidLaunchedTheShipToGetHisPad)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(ZaidLaunchedTheShip)) 
                && (CurrentGameState.IsThinking(nameof(IWontSealYourFate)) 
                    || CurrentGameState.IsThinking(nameof(YouBroughtThisOnYourself)));
        }
    }
}
