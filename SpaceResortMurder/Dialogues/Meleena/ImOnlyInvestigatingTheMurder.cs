using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class ImOnlyInvestigatingTheMurder : Dialogue
    {
        public ImOnlyInvestigatingTheMurder() : base(nameof(ImOnlyInvestigatingTheMurder)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(SearchYourCraftForEvidence))
                && !CurrentGameState.IsThinking(nameof(HereIsTheSearchOrder));
        }
    }
}
