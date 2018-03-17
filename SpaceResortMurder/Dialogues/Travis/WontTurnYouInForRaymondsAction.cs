using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Travis
{
    public class WontTurnYouInForRaymondsAction : Dialogue
    {
        public WontTurnYouInForRaymondsAction() : base(nameof(WontTurnYouInForRaymondsAction))
        {
            IsExclusive = true;
        }

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(ExplainTheCloningMachine));
        }
    }
}
