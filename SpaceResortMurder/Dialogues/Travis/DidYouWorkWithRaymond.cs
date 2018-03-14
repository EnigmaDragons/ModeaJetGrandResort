using SpaceResortMurder.Dialogues.Warren;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Travis
{
    public class DidYouWorkWithRaymond : Dialogue
    {
        public DidYouWorkWithRaymond() : base(nameof(DidYouWorkWithRaymond)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(MeetingWarren));
        }
    }
}
