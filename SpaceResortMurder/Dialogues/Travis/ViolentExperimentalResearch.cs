using SpaceResortMurder.Clues.MeleenasSpaceCraft;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Travis
{
    public class ViolentExperimentalResearch : Dialogue
    {
        public ViolentExperimentalResearch() : base(nameof(ViolentExperimentalResearch)) {}

        public override bool IsActive()
        {
            return (CurrentGameState.IsThinking(nameof(YouAreStillResposible))
                    || CurrentGameState.IsThinking(nameof(WontTurnYouInForRaymondsAction)))
                && CurrentGameState.IsThinking(nameof(UnencryptedDataDrive))
                && CurrentGameState.IsThinking(nameof(YourBrotherWasKilled));
        }
    }
}
