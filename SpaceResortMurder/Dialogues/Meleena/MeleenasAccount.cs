using SpaceResortMurder.Dialogues.Warren;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class MeleenasAccount : Dialogue
    {
        public MeleenasAccount() : base(nameof(MeleenasAccount)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(MeetingWarren));
        }
    }
}
