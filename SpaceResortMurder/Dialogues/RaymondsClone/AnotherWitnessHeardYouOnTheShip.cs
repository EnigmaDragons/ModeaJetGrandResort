using SpaceResortMurder.Deductions.BruisesCameFrom;
using SpaceResortMurder.Deductions.ClonesDesign;
using SpaceResortMurder.Deductions.LaunchedTheShip;
using SpaceResortMurder.Dialogues.Meleena;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.RaymondsClone
{
    public class AnotherWitnessHeardYouOnTheShip : Dialogue
    {
        public AnotherWitnessHeardYouOnTheShip() : base(nameof(AnotherWitnessHeardYouOnTheShip)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(RaymondLaunchedTheShip)) 
                && CurrentGameState.IsThinking(nameof(YouBrokeIntoRaymondsShip))
                && CurrentGameState.IsThinking(nameof(FoundYouRaymondsClone))
                && !(CurrentGameState.IsThinking(nameof(BruisesCameFromAStruggle))
                   && CurrentGameState.IsThinking(nameof(DesignedToKill)));
        }
    }
}
