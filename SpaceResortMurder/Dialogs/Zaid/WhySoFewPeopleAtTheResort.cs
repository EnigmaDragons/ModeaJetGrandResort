using SpaceResortMurder.Dialogs.Warren;

namespace SpaceResortMurder.Dialogs.Zaid
{
    public class WhySoFewPeopleAtTheResort : Dialog
    {
        public WhySoFewPeopleAtTheResort() : base(nameof(WhySoFewPeopleAtTheResort)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(MeetingWarren));
        }

        public override bool IsImmediatelyStarted()
        {
            return false;
        }
    }
}
