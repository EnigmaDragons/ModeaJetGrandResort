using SpaceResortMurder.Clues.MeleenasSpaceCraft;
using SpaceResortMurder.Deductions;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class ProveIt : Dialogue
    {
        public ProveIt() : base(nameof(ProveIt)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(MeleenaHackedTheDoor))
                && !CurrentGameState.IsThinking(nameof(SkeletonKey));
        }
    }
}
