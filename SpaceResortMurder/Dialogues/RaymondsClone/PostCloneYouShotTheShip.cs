using SpaceResortMurder.Clues.RaymondsSpaceCraft;
using SpaceResortMurder.Deductions;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.RaymondsClone
{
    public class PostCloneYouShotTheShip : Dialogue
    {
        public PostCloneYouShotTheShip() : base(nameof(PostCloneYouShotTheShip)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(RaymondsCloneShotRaymondsShip)) 
                && CurrentGameState.IsThinking(nameof(YourBeingRidiculous))
                && CurrentGameState.IsThinking(nameof(T71EnergyBlaster));
        }
    }
}
