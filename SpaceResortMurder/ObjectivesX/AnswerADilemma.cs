using SpaceResortMurder.Clues.PoliceSpaceCraft;
using SpaceResortMurder.Deductions.TimeFrameForMurder;
using SpaceResortMurder.State;

namespace SpaceResortMurder.ObjectivesX
{
    public class AnswerADilemma : Objective
    {
        public AnswerADilemma() : base(nameof(AnswerADilemma)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(Clock))
                && !(CurrentGameState.IsThinking(nameof(FromAnytimeUntilEightPM))
                    || CurrentGameState.IsThinking(nameof(SevenAMToEightPM))
                    || CurrentGameState.IsThinking(nameof(EightPMtoMidnight)));
        }
    }
}
