namespace SpaceResortMurder.Dialogues.Meleena
{
    public class ImOnlyInvestigatingTheMurder : Dialogue
    {
        public ImOnlyInvestigatingTheMurder() : base(nameof(ImOnlyInvestigatingTheMurder)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(SearchYourCraftForEvidence))
                && !GameState.Instance.IsThinking(nameof(HereIsTheSearchOrder));
        }
    }
}
