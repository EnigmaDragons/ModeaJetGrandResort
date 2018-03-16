using SpaceResortMurder.Clues.MeleenasSpaceCraft;
using SpaceResortMurder.Dialogues.Meleena;
using SpaceResortMurder.State;

namespace SpaceResortMurder.ObjectivesX
{
    public class CheckWhatsOnMeleenasDataDrive : Objective
    {
        public CheckWhatsOnMeleenasDataDrive() : base(nameof(CheckWhatsOnMeleenasDataDrive)) {}

        public override bool IsActive() => (CurrentGameState.IsThinking(nameof(IWontReportDataRaven))
                || CurrentGameState.IsThinking(nameof(DeckersMakeTheWorldWorse)))
            && !CurrentGameState.IsThinking(nameof(UnencryptedDataDrive));
    }
}
