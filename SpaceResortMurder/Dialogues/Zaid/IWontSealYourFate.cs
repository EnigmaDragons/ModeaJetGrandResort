using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Zaid
{
    public class IWontSealYourFate : Dialogue
    {
        public IWontSealYourFate() : base(nameof(IWontSealYourFate)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(YouWereNotAcceptedForBetaTesting))
                && !CurrentGameState.IsThinking(nameof(YouBroughtThisOnYourself));
        }
    }
}
