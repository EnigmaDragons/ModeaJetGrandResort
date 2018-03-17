using SpaceResortMurder.Deductions.LaunchedTheShip;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.RaymondsClone
{
    public class PostCloneYouLaunchedTheShip : Dialogue
    {
        public PostCloneYouLaunchedTheShip() : base(nameof(PostCloneYouLaunchedTheShip)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(RaymondsCloneLaunchedTheShip)) 
                && CurrentGameState.IsThinking(nameof(YourBeingRidiculous));
        }
    }
}
