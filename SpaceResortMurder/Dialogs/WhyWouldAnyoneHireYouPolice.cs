namespace SpaceResortMurder.Dialogs
{
    public class WhyWouldAnyoneHireYouPolice : Dialog
    {
        public WhyWouldAnyoneHireYouPolice() : base("Why the hell were you hired?", nameof(WhyWouldAnyoneHireYouPolice), 1600) {}

        public override bool IsActive()
        {
            return true;
        }

        public override bool IsImmediatelyStarted()
        {
            return false;
        }
    }
}
