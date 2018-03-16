using SpaceResortMurder.Clues.MeleenasSpaceCraft;
using SpaceResortMurder.Dialogues.Meleena;
using SpaceResortMurder.State;

namespace SpaceResortMurder.ObjectivesX
{
    public class GetAnEncryptionKeyForMeleenasDataDrive : Objective
    {
        public GetAnEncryptionKeyForMeleenasDataDrive() : base(nameof(GetAnEncryptionKeyForMeleenasDataDrive)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(EncryptedDataDrive))
                && !(CurrentGameState.IsThinking(nameof(CareToShowTheDirtYouCollected))
                    || CurrentGameState.IsThinking(nameof(ObstructionOfJusticeWillAddToYourPrisonTime))
                    || CurrentGameState.IsThinking(nameof(WontTurnYouInIfYouUnencryptThisDrive)));
        }
    }
}
