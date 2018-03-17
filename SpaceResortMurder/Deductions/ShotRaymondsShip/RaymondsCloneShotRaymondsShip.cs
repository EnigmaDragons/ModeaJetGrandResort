using SpaceResortMurder.Dialogues.Travis;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions
{
    public class RaymondsCloneShotRaymondsShip : Deduction
    {
        public RaymondsCloneShotRaymondsShip() : base(nameof(RaymondsCloneShotRaymondsShip)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(TravissAccount));
        }
    }
}
