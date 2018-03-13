namespace SpaceResortMurder.Dialogues.Meleena
{
    public class ObstructionOfJusticeWillAddToYourPrisonTime : Dialogue
    {
        public ObstructionOfJusticeWillAddToYourPrisonTime() : base(nameof(ObstructionOfJusticeWillAddToYourPrisonTime)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(YouNeedToUnencryptThisDataStick))
                   && !GameState.Instance.IsThinking(nameof(WontTurnYouInIfYouUnencryptThisDrive));
        }
    }
}
