using SpaceResortMurder.CharactersX;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Zaid
{
    public class ZaidsAccount : Dialogue
    {
        public ZaidsAccount() : base(nameof(ZaidsAccount)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(WhoAreYouZaid)) || CurrentGameState.IsThinking(nameof(ResortManagerZaid)); 
        }
    }
}
