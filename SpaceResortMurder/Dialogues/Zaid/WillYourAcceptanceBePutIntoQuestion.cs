using SpaceResortMurder.Deductions.ZaidsResortForBetaTesting;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Zaid
{
    public class WillYourAcceptanceBePutIntoQuestion : Dialogue
    {
        public WillYourAcceptanceBePutIntoQuestion() : base(nameof(WillYourAcceptanceBePutIntoQuestion)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(ZaidsResortAccepted));
        }
    }
}
