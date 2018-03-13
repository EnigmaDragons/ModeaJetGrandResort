using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class WontTurnYouInIfYouUnencryptThisDrive : Dialogue
    {
        public WontTurnYouInIfYouUnencryptThisDrive() : base(nameof(WontTurnYouInIfYouUnencryptThisDrive)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(YouNeedToUnencryptThisDataStick))
                   && !CurrentGameState.Instance.IsThinking(nameof(ObstructionOfJusticeWillAddToYourPrisonTime));
        }
    }
}
