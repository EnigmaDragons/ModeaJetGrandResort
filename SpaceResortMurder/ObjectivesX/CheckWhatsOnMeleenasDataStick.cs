using SpaceResortMurder.Dialogues.Meleena;

namespace SpaceResortMurder.ObjectivesX
{
    public class CheckWhatsOnMeleenasDataStick : Objective
    {
        public CheckWhatsOnMeleenasDataStick() : base(nameof(CheckWhatsOnMeleenasDataStick)) {}

        public override bool IsActive()
        {
            return (GameState.Instance.IsThinking(nameof(CareToShowTheDirtYouCollected))
                || GameState.Instance.IsThinking(nameof(ObstructionOfJusticeWillAddToYourPrisonTime))
                || GameState.Instance.IsThinking(nameof(WontTurnYouInIfYouUnencryptThisDrive)));
        }
    }
}
