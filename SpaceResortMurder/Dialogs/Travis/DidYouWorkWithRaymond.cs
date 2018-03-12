using SpaceResortMurder.Dialogs.Warren;

namespace SpaceResortMurder.Dialogs.Travis
{
    public class DidYouWorkWithRaymond : Dialog
    {
        public DidYouWorkWithRaymond() : base(nameof(DidYouWorkWithRaymond)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(MeetingWarren));
        }

        public override bool IsImmediatelyStarted()
        {
            return false;
        }
    }
}
