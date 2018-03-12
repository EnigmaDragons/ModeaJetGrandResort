using SpaceResortMurder.Dialogs.Warren;

namespace SpaceResortMurder.Dialogs.Meleena
{
    public class MeleenasAccount : Dialog
    {
        public MeleenasAccount() : base(nameof(MeleenasAccount)) {}

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
