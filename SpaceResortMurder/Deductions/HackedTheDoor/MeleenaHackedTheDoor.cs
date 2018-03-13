using SpaceResortMurder.Dialogues.Warren;

namespace SpaceResortMurder.Deductions
{
    public class MeleenaHackedTheDoor : Deduction
    {
        public MeleenaHackedTheDoor() : base(nameof(MeleenaHackedTheDoor)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(MeetingWarren));
        }
    }
}
