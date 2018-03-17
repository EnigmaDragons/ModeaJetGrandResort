using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class DeckersMakeTheWorldWorse : Dialogue
    {
        public DeckersMakeTheWorldWorse() : base(nameof(DeckersMakeTheWorldWorse))
        {
            IsExclusive = true;
        }

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(YouAreAHacker));
        }
    }
}
