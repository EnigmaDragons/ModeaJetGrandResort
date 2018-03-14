using SpaceResortMurder.Dialogues.Warren;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions
{
    public class ZaidHackedTheDoor : Deduction
    {
        public ZaidHackedTheDoor() : base(nameof(ZaidHackedTheDoor)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(MeetingWarren));
        }
    }
}
