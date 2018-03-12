using SpaceResortMurder.Deductions.ZaidsResortForBetaTesting;

namespace SpaceResortMurder.Dialogs.Zaid
{
    public class YouWereNotAcceptedForBetaTesting : Dialog
    {
        public YouWereNotAcceptedForBetaTesting() : base(nameof(YouWereNotAcceptedForBetaTesting)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(ZaidsResortDeclined)) 
                && GameState.Instance.IsThinking(nameof(DidRaymondApproveYourResort));
        }

        public override bool IsImmediatelyStarted()
        {
            return false;
        }
    }
}
