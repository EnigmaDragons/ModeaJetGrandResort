using SpaceResortMurder.Dialogues.Meleena;
using SpaceResortMurder.State;

namespace SpaceResortMurder.ObjectivesX
{
    public class CheckWhatsOnMeleenasDataDrive : Objective
    {
        public CheckWhatsOnMeleenasDataDrive() : base(nameof(CheckWhatsOnMeleenasDataDrive)) {}

        public override bool IsActive() => (CurrentGameState.IsThinking(nameof(CareToShowTheDirtYouCollected))
                || CurrentGameState.IsThinking(nameof(ObstructionOfJusticeWillAddToYourPrisonTime))
                || CurrentGameState.IsThinking(nameof(WontTurnYouInIfYouUnencryptThisDrive)));
    }
}
