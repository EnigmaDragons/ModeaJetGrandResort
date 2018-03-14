using SpaceResortMurder.Deductions.ZaidsResortForBetaTesting;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Zaid
{
    public class YouWereNotAcceptedForBetaTesting : Dialogue
    {
        public YouWereNotAcceptedForBetaTesting() : base(nameof(YouWereNotAcceptedForBetaTesting)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(ZaidsResortDeclined)) 
                && CurrentGameState.IsThinking(nameof(DidRaymondApproveYourResort));
        }
    }
}
