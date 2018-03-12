using SpaceResortMurder.Dialogs.Warren;

namespace SpaceResortMurder.Deductions
{
    public class ZaidHackedTheDoor : Deduction
    {
        public ZaidHackedTheDoor() : base(nameof(ZaidHackedTheDoor)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(MeetingWarren));
        }
    }
}
