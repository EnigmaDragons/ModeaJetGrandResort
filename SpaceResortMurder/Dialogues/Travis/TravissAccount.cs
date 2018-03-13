namespace SpaceResortMurder.Dialogues.Travis
{
    public class TravissAccount : Dialogue
    {
        public TravissAccount() : base(nameof(TravissAccount)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(WhyIsTravisAtTheResort));
        }
    }
}
