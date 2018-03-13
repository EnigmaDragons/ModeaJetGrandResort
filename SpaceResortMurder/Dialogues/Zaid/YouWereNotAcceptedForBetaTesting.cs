using SpaceResortMurder.Deductions.ZaidsResortForBetaTesting;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Zaid
{
    public class YouWereNotAcceptedForBetaTesting : Dialogue
    {
        public YouWereNotAcceptedForBetaTesting() : base(nameof(YouWereNotAcceptedForBetaTesting)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(ZaidsResortDeclined)) 
                && CurrentGameState.Instance.IsThinking(nameof(DidRaymondApproveYourResort));
        }
    }
}
