using SpaceResortMurder.Deductions.TimeFrameForMurder;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Warren
{
    public class BetweenSevenAMToEightPM : Dialogue
    {
        public BetweenSevenAMToEightPM() : base(nameof(BetweenSevenAMToEightPM)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(SevenAMToEightPM));
        }
    }
}
