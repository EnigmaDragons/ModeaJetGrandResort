using SpaceResortMurder.Clues.RaymondsSpaceCraft;
using SpaceResortMurder.Dialogues.Warren;
using SpaceResortMurder.State;

namespace SpaceResortMurder.ObjectivesX
{
    public class InvestigateRaymondsDeadBody : Objective
    {
        public InvestigateRaymondsDeadBody() : base(nameof(InvestigateRaymondsDeadBody)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(BetweenSevenAMToEightPM)) 
                && !CurrentGameState.IsThinking(nameof(RaymondsCorpse));
        }
    }
}
