using SpaceResortMurder.Clues.DockingBay;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class SearchYourCraftForEvidence : Dialogue
    {
        public SearchYourCraftForEvidence() : base(nameof(SearchYourCraftForEvidence)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(MeleenasShip));
        }
    }
}
