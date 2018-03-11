namespace SpaceResortMurder.Dialogs.Zaid
{
    public class WhyWasRaymondHere : Dialog
    {
        public WhyWasRaymondHere() : base(nameof(WhyWasRaymondHere)) {}

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
