using SpaceResortMurder.Clues.DockingBay;

namespace SpaceResortMurder.Dialogues.Zaid
{
    public class DidYouReleaseTheGarbage : Dialogue
    {
        public DidYouReleaseTheGarbage() : base(nameof(DidYouReleaseTheGarbage)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(GarbageAirlock));
        }
    }
}
