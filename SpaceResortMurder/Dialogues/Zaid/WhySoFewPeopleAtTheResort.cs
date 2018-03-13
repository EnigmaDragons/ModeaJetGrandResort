using SpaceResortMurder.Dialogues.Warren;

namespace SpaceResortMurder.Dialogues.Zaid
{
    public class WhySoFewPeopleAtTheResort : Dialogue
    {
        public WhySoFewPeopleAtTheResort() : base(nameof(WhySoFewPeopleAtTheResort)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(MeetingWarren));
        }
    }
}
