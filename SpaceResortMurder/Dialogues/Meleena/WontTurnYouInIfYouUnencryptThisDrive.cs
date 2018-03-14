using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class WontTurnYouInIfYouUnencryptThisDrive : Dialogue
    {
        public WontTurnYouInIfYouUnencryptThisDrive() : base(nameof(WontTurnYouInIfYouUnencryptThisDrive)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(YouNeedToUnencryptThisDataStick))
                   && !CurrentGameState.IsThinking(nameof(ObstructionOfJusticeWillAddToYourPrisonTime));
        }
    }
}
