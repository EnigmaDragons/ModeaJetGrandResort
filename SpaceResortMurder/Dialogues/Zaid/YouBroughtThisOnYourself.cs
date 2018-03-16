using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Zaid
{
    public class YouBroughtThisOnYourself : Dialogue
    {
        public YouBroughtThisOnYourself() : base(nameof(YouBroughtThisOnYourself)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(YouWereNotAcceptedForBetaTesting))
                && !CurrentGameState.IsThinking(nameof(IWontSealYourFate));
        }
    }
}
