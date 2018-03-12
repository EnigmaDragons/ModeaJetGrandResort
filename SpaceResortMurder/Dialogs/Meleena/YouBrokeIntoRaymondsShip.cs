using SpaceResortMurder.Clues.MeleenasSpaceCraft;
using SpaceResortMurder.Deductions;

namespace SpaceResortMurder.Dialogs.Meleena
{
    public class YouBrokeIntoRaymondsShip : Dialog
    {
        public YouBrokeIntoRaymondsShip() : base(nameof(YouBrokeIntoRaymondsShip)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(SkeletonKey))
                   && GameState.Instance.IsThinking(nameof(MeleenaHackedTheDoor));
        }

        public override bool IsImmediatelyStarted()
        {
            return false;
        }
    }
}
