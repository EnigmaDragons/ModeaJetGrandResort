namespace SpaceResortMurder.Dialogs.Zaid
{
    public class ZaidsAccount : Dialog
    {
        public ZaidsAccount() : base(nameof(ZaidsAccount)) {}

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
