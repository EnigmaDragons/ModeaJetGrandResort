using SpaceResortMurder.Clues.MeleenasSpaceCraft;
using SpaceResortMurder.Deductions;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class YouBrokeIntoRaymondsShip : Dialogue
    {
        public YouBrokeIntoRaymondsShip() : base(nameof(YouBrokeIntoRaymondsShip)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(SkeletonKey))
                   && GameState.Instance.IsThinking(nameof(MeleenaHackedTheDoor));
        }
    }
}
