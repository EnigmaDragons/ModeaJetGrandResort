using SpaceResortMurder.Dialogues.Warren;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions
{
    public class MeleenaHackedTheDoor : Deduction
    {
        public MeleenaHackedTheDoor() : base(nameof(MeleenaHackedTheDoor)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(MeetingWarren));
        }
    }
}
