namespace SpaceResortMurder.Dialogs
{
    public class WhyWouldAnyoneHireYouPolice : Dialog
    {
        public WhyWouldAnyoneHireYouPolice() : base("Why the hell were you hired?", nameof(WhyWouldAnyoneHireYouPolice), 1600, "because im the best you scrub!") {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
