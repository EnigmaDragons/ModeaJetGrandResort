using SpaceResortMurder.Dialogues.Warren;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.LaunchedTheShip
{
    public class ZaidLaunchedTheShip : Deduction
    {
        public ZaidLaunchedTheShip() : base(nameof(ZaidLaunchedTheShip)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(MeetingWarren));
        }
    }
}
