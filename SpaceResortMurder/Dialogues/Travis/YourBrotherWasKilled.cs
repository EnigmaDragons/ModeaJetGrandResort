using SpaceResortMurder.Clues.MeleenasSpaceCraft;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Travis
{
    public class YourBrotherWasKilled : Dialogue
    {
        public YourBrotherWasKilled() : base(nameof(YourBrotherWasKilled)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(UnencryptedDataStick));
        }
    }
}
