using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class ObstructionOfJusticeWillAddToYourPrisonTime : Dialogue
    {
        public ObstructionOfJusticeWillAddToYourPrisonTime() : base(nameof(ObstructionOfJusticeWillAddToYourPrisonTime)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(YouNeedToUnencryptThisDataStick))
                   && !CurrentGameState.IsThinking(nameof(WontTurnYouInIfYouUnencryptThisDrive));
        }
    }
}
