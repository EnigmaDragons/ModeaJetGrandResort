using SpaceResortMurder.Dialogues.RaymondsClone;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Travis
{
    public class CloningMalfunction : Dialogue
    {
        public CloningMalfunction() : base(nameof(CloningMalfunction)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(ElectricDischarge)) 
                && (CurrentGameState.IsThinking(nameof(YouAreStillResposible))
                    || CurrentGameState.IsThinking(nameof(WontTurnYouInForRaymondsAction)));
        }
    }
}
