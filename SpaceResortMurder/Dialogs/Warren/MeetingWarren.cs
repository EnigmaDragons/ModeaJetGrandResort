namespace SpaceResortMurder.Dialogs.Warren
{
    public class MeetingWarren : Dialog
    {
        public MeetingWarren() : base(nameof(MeetingWarren)) {}

        public override bool IsActive()
        {
            return true;
        }

        public override bool IsImmediatelyStarted()
        {
            return !GameState.Instance.HasViewedItem(nameof(MeetingWarren));
        }
    }
}
