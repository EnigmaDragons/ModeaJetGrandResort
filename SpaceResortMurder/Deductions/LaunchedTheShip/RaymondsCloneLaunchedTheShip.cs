using SpaceResortMurder.Dialogues.RaymondsClone;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.LaunchedTheShip
{
    public class RaymondsCloneLaunchedTheShip : Deduction
    {
        public RaymondsCloneLaunchedTheShip() : base(nameof(RaymondsCloneLaunchedTheShip)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(MeetingRaymondsClone));
        }
    }
}
