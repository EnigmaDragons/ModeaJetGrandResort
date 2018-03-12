using SpaceResortMurder.Clues;
using SpaceResortMurder.Clues.DockingBay;

namespace SpaceResortMurder.Dialogs.Zaid
{
    public class DidYouReleaseTheGarbage : Dialog
    {
        public DidYouReleaseTheGarbage() : base(nameof(DidYouReleaseTheGarbage)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(GarbageAirlock));
        }

        public override bool IsImmediatelyStarted()
        {
            return false;
        }
    }
}
