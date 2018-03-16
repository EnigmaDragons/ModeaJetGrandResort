using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Travis
{
    public class WontTurnYouInForRaymondsAction : Dialogue
    {
        public WontTurnYouInForRaymondsAction() : base(nameof(WontTurnYouInForRaymondsAction)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(ExplainTheCloningMachine));
        }
    }
}
