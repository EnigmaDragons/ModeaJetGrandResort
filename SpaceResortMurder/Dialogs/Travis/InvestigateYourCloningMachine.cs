namespace SpaceResortMurder.Dialogs.Travis
{
    public class InvestigateYourCloningMachine : Dialog
    {
        public InvestigateYourCloningMachine() : base(nameof(InvestigateYourCloningMachine)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(TravissAccount));
        }

        public override bool IsImmediatelyStarted()
        {
            return false;
        }
    }
}
