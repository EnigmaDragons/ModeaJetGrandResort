using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Zaid
{
    public class DidRaymondApproveYourResort : Dialogue
    {
        public DidRaymondApproveYourResort() : base(nameof(DidRaymondApproveYourResort)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(WhyWasRaymondHere));
        }
    }
}
