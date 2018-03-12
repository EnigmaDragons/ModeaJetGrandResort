namespace SpaceResortMurder.Dialogs.Meleena
{
    public class ImOnlyInvestigatingTheMurder : Dialog
    {
        public ImOnlyInvestigatingTheMurder() : base(nameof(ImOnlyInvestigatingTheMurder)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(SearchYourCraftForEvidence))
                && !GameState.Instance.IsThinking(nameof(HereIsTheSearchOrder));
        }

        public override bool IsImmediatelyStarted()
        {
            return false;
        }
    }
}
