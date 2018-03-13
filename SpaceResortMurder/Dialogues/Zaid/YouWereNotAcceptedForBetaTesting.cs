using SpaceResortMurder.Deductions.ZaidsResortForBetaTesting;

namespace SpaceResortMurder.Dialogues.Zaid
{
    public class YouWereNotAcceptedForBetaTesting : Dialogue
    {
        public YouWereNotAcceptedForBetaTesting() : base(nameof(YouWereNotAcceptedForBetaTesting)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(ZaidsResortDeclined)) 
                && GameState.Instance.IsThinking(nameof(DidRaymondApproveYourResort));
        }
    }
}
