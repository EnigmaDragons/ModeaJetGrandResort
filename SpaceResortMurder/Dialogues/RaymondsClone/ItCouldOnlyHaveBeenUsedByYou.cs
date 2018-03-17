using SpaceResortMurder.Clues.RaymondsSpaceCraft;
using SpaceResortMurder.Deductions;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.RaymondsClone
{
    public class ItCouldOnlyHaveBeenUsedByYou : Dialogue
    {
        public ItCouldOnlyHaveBeenUsedByYou() : base(nameof(ItCouldOnlyHaveBeenUsedByYou)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(RaymondsCloneShotRaymondsShip)) 
                && CurrentGameState.IsThinking(nameof(T71EnergyBlaster))
                && CurrentGameState.IsThinking(nameof(FoundYouRaymondsClone));
        }
    }
}
