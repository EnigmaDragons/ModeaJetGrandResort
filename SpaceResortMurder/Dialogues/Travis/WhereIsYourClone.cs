using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Travis
{
    public class WhereIsYourClone : Dialogue
    {
        public WhereIsYourClone() : base(nameof(WhereIsYourClone)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(TravissAccount));
        }
    }
}
