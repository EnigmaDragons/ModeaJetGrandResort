using SpaceResortMurder.Dialogs.Warren;

namespace SpaceResortMurder.Dialogs.Travis
{
    public class TravissAccount : Dialog
    {
        public TravissAccount() : base(nameof(TravissAccount)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(WhyIsTravisAtTheResort));
        }

        public override bool IsImmediatelyStarted()
        {
            return false;
        }
    }
}
