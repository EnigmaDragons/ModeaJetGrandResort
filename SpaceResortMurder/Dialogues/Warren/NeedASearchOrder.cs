using SpaceResortMurder.Dialogues.Meleena;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Warren
{
    public class NeedASearchOrder : Dialogue
    {
        public NeedASearchOrder() : base(nameof(NeedASearchOrder)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(SearchYourCraftForEvidence)) 
                && !CurrentGameState.Instance.IsThinking(nameof(ImOnlyInvestigatingTheMurder));
        }
    }
}
