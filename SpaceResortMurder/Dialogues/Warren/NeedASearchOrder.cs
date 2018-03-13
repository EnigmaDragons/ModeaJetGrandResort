using SpaceResortMurder.Dialogues.Meleena;

namespace SpaceResortMurder.Dialogues.Warren
{
    public class NeedASearchOrder : Dialogue
    {
        public NeedASearchOrder() : base(nameof(NeedASearchOrder)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(SearchYourCraftForEvidence)) 
                && !GameState.Instance.IsThinking(nameof(ImOnlyInvestigatingTheMurder));
        }
    }
}
