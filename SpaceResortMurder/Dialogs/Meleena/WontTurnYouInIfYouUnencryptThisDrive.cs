namespace SpaceResortMurder.Dialogs.Meleena
{
    public class WontTurnYouInIfYouUnencryptThisDrive : Dialog
    {
        public WontTurnYouInIfYouUnencryptThisDrive() : base(nameof(WontTurnYouInIfYouUnencryptThisDrive)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(YouNeedToUnencryptThisDataStick))
                   && !GameState.Instance.IsThinking(nameof(ObstructionOfJusticeWillAddToYourPrisonTime));
        }

        public override bool IsImmediatelyStarted()
        {
            return false;
        }
    }
}
