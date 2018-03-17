using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Zaid
{
    public class IWontSealYourFate : Dialogue
    {
        public IWontSealYourFate() : base(nameof(IWontSealYourFate))
        {
            IsExclusive = true;
        }

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(YouWereNotAcceptedForBetaTesting))
                && !CurrentGameState.IsThinking(nameof(YouBroughtThisOnYourself));
        }
    }
}
