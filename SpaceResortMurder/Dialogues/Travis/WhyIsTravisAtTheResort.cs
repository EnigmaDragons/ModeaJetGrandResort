using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Travis
{
    public class WhyIsTravisAtTheResort : Dialogue
    {
        public WhyIsTravisAtTheResort() : base(nameof(WhyIsTravisAtTheResort)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(DidYouWorkWithRaymond));
        }
    }
}
