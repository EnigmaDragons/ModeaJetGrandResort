using SpaceResortMurder.Dialogues.Warren;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.LaunchedTheShip
{
    public class RaymondLaunchedTheShip : Deduction
    {
        public RaymondLaunchedTheShip() : base(nameof(RaymondLaunchedTheShip)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(MeetingWarren));
        }
    }
}
