using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class ImOnlyInvestigatingTheMurder : Dialogue
    {
        public ImOnlyInvestigatingTheMurder() : base(nameof(ImOnlyInvestigatingTheMurder)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(SearchYourCraftForEvidence))
                && !CurrentGameState.Instance.IsThinking(nameof(HereIsTheSearchOrder));
        }
    }
}
