using SpaceResortMurder.Deductions.TimeFrameForMurder;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Warren
{
    public class WeHaveUntilMidnight : Dialogue
    {
        public WeHaveUntilMidnight() : base(nameof(WeHaveUntilMidnight)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(EightPMtoMidnight));
        }
    }
}
