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
            return CurrentGameState.Instance.IsThinking(nameof(Clock))
                   && !(CurrentGameState.Instance.IsThinking(nameof(FromAnytimeUntilEightPM))
                        || CurrentGameState.Instance.IsThinking(nameof(SevenAMToEightPM))
                        || CurrentGameState.Instance.IsThinking(nameof(EightPMtoMidnight)));
        }
    }
}
