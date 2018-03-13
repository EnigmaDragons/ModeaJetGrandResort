namespace SpaceResortMurder.Dialogues.Meleena
{
    public class WontTurnYouInIfYouUnencryptThisDrive : Dialogue
    {
        public WontTurnYouInIfYouUnencryptThisDrive() : base(nameof(WontTurnYouInIfYouUnencryptThisDrive)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(YouNeedToUnencryptThisDataStick))
                   && !GameState.Instance.IsThinking(nameof(ObstructionOfJusticeWillAddToYourPrisonTime));
        }
    }
}
