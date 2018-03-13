using SpaceResortMurder.Dialogues.Warren;

namespace SpaceResortMurder.Deductions
{
    public class TravisHackedTheDoor : Deduction
    {
        public TravisHackedTheDoor() : base(nameof(TravisHackedTheDoor)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(MeetingWarren));
        }
    }
}
