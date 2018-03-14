using SpaceResortMurder.Dialogues.Meleena;
using SpaceResortMurder.State;

namespace SpaceResortMurder.ObjectivesX
{
    public class CheckWhatsOnMeleenasDataStick : Objective
    {
        public CheckWhatsOnMeleenasDataStick() : base(nameof(CheckWhatsOnMeleenasDataStick)) {}

        public override bool IsActive() => (CurrentGameState.IsThinking(nameof(CareToShowTheDirtYouCollected))
                || CurrentGameState.IsThinking(nameof(ObstructionOfJusticeWillAddToYourPrisonTime))
                || CurrentGameState.IsThinking(nameof(WontTurnYouInIfYouUnencryptThisDrive)));
    }
}
