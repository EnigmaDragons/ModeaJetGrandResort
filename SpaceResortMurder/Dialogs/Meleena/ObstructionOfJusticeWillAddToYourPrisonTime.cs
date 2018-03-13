namespace SpaceResortMurder.Dialogs.Meleena
{
    public class ObstructionOfJusticeWillAddToYourPrisonTime : Dialog
    {
        public ObstructionOfJusticeWillAddToYourPrisonTime() : base(nameof(ObstructionOfJusticeWillAddToYourPrisonTime)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(YouNeedToUnencryptThisDataStick))
                   && !GameState.Instance.IsThinking(nameof(WontTurnYouInIfYouUnencryptThisDrive));
        }

        public override bool IsImmediatelyStarted()
        {
            return false;
        }
    }
}
