using SpaceResortMurder.Clues.RaymondsSpaceCraft;
using SpaceResortMurder.Dialogues.Warren;
using SpaceResortMurder.State;

namespace SpaceResortMurder.ObjectivesX
{
    public class InvestigateRaymondsShip : Objective
    {
        public InvestigateRaymondsShip() : base(nameof(InvestigateRaymondsShip)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(BetweenSevenAMToEightPM)) 
                && !(CurrentGameState.IsThinking(nameof(RaymondsCorpse)) 
                    && CurrentGameState.IsThinking(nameof(RaymondsPad)) 
                    && CurrentGameState.IsThinking(nameof(ShipsLogs)));
        }
    }
}
