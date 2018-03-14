using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Zaid
{
    public class DidRaymondApproveYourResort : Dialogue
    {
        public DidRaymondApproveYourResort() : base(nameof(DidRaymondApproveYourResort)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(WhyWasRaymondHere));
        }
    }
}
