using SpaceResortMurder.Dialogues.Meleena;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Warren
{
    public class NeedASearchOrder : Dialogue
    {
        public NeedASearchOrder() : base(nameof(NeedASearchOrder)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(SearchYourCraftForEvidence));
        }
    }
}
