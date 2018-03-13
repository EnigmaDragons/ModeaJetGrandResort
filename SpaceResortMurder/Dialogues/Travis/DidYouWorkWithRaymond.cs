using SpaceResortMurder.Dialogues.Warren;

namespace SpaceResortMurder.Dialogues.Travis
{
    public class DidYouWorkWithRaymond : Dialogue
    {
        public DidYouWorkWithRaymond() : base(nameof(DidYouWorkWithRaymond)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(MeetingWarren));
        }
    }
}
