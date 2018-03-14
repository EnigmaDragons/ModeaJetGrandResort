using SpaceResortMurder.Deductions.TimeFrameForMurder;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Warren
{
    public class AnytimeUpTilNow : Dialogue
    {
        public AnytimeUpTilNow() : base(nameof(AnytimeUpTilNow)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(FromAnytimeUntilEightPM));
        }
    }
}
