using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class ObstructionOfJusticeWillAddToYourPrisonTime : Dialogue
    {
        public ObstructionOfJusticeWillAddToYourPrisonTime() : base(nameof(ObstructionOfJusticeWillAddToYourPrisonTime)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(YouNeedToUnencryptThisDataStick))
                   && !CurrentGameState.Instance.IsThinking(nameof(WontTurnYouInIfYouUnencryptThisDrive));
        }
    }
}
