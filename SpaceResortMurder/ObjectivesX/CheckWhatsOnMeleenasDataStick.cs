using SpaceResortMurder.Dialogues.Meleena;
using SpaceResortMurder.State;

namespace SpaceResortMurder.ObjectivesX
{
    public class CheckWhatsOnMeleenasDataStick : Objective
    {
        public CheckWhatsOnMeleenasDataStick() : base(nameof(CheckWhatsOnMeleenasDataStick)) {}

        public override bool IsActive() => (CurrentGameState.Instance.IsThinking(nameof(CareToShowTheDirtYouCollected))
                || CurrentGameState.Instance.IsThinking(nameof(ObstructionOfJusticeWillAddToYourPrisonTime))
                || CurrentGameState.Instance.IsThinking(nameof(WontTurnYouInIfYouUnencryptThisDrive)));
    }
}
