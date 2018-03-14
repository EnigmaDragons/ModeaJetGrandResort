using SpaceResortMurder.Clues.MeleenasSpaceCraft;
using SpaceResortMurder.Dialogues.Meleena;
using SpaceResortMurder.State;

namespace SpaceResortMurder.ObjectivesX
{
    public class GetAnEncryptionKeyForMeleenasDataStick : Objective
    {
        public GetAnEncryptionKeyForMeleenasDataStick() : base(nameof(GetAnEncryptionKeyForMeleenasDataStick)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(DataStick))
                && !(CurrentGameState.IsThinking(nameof(CareToShowTheDirtYouCollected))
                    || CurrentGameState.IsThinking(nameof(ObstructionOfJusticeWillAddToYourPrisonTime))
                    || CurrentGameState.IsThinking(nameof(WontTurnYouInIfYouUnencryptThisDrive)));
        }
    }
}
