using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Travis
{
    public class TravissAccount : Dialogue
    {
        public TravissAccount() : base(nameof(TravissAccount)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(WhyIsTravisAtTheResort));
        }
    }
}
