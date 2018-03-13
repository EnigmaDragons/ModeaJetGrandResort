using SpaceResortMurder.Clues.DockingBay;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class SearchYourCraftForEvidence : Dialogue
    {
        public SearchYourCraftForEvidence() : base(nameof(SearchYourCraftForEvidence)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(MeleenasShip));
        }
    }
}
