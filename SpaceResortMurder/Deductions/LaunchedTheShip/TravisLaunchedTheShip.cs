using SpaceResortMurder.Dialogues.Warren;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.LaunchedTheShip
{
    public class TravisLaunchedTheShip : Deduction
    {
        public TravisLaunchedTheShip() : base(nameof(TravisLaunchedTheShip)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(MeetingWarren));
        }
    }
}
