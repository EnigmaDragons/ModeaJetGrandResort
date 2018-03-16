using SpaceResortMurder.Dialogues.RaymondsClone;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Travis
{
    public class MatterRemovalBruises : Dialogue
    {
        public MatterRemovalBruises() : base(nameof(MatterRemovalBruises)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(Bruises)) 
                && (CurrentGameState.IsThinking(nameof(YouAreStillResposible))
                    || CurrentGameState.IsThinking(nameof(WontTurnYouInForRaymondsAction)));
        }
    }
}
