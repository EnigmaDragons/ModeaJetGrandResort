using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Travis
{
    public class YouAreStillResposible : Dialogue
    {
        public YouAreStillResposible() : base(nameof(YouAreStillResposible))
        {
            IsExclusive = true;
        }

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(ExplainTheCloningMachine)) 
                && !CurrentGameState.IsThinking(nameof(WontTurnYouInForRaymondsAction));
        }
    }
}
