using SpaceResortMurder.Dialogs.Meleena;

namespace SpaceResortMurder.Dialogs.Warren
{
    public class INeedASearchOrder : Dialog
    {
        public INeedASearchOrder() : base(nameof(INeedASearchOrder)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(SearchYourCraftForEvidence)) 
                && !GameState.Instance.IsThinking(nameof(ImOnlyInvestigatingTheMurder));
        }

        public override bool IsImmediatelyStarted()
        {
            return false;
        }
    }
}
