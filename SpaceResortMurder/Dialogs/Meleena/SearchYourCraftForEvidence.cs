using SpaceResortMurder.Clues.DockingBay;

namespace SpaceResortMurder.Dialogs.Meleena
{
    public class SearchYourCraftForEvidence : Dialog
    {
        public SearchYourCraftForEvidence() : base(nameof(SearchYourCraftForEvidence)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(MeleenasShip));
        }

        public override bool IsImmediatelyStarted()
        {
            return false;
        }
    }
}
