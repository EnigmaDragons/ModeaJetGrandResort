using SpaceResortMurder.Clues.MeleenasSpaceCraft;
using SpaceResortMurder.Dialogues.Meleena;

namespace SpaceResortMurder.ObjectivesX
{
    public class GetAnEncryptionKeyForMeleenasDataStick : Objective
    {
        public GetAnEncryptionKeyForMeleenasDataStick() : base(nameof(GetAnEncryptionKeyForMeleenasDataStick)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(DataStick))
                && !(GameState.Instance.IsThinking(nameof(CareToShowTheDirtYouCollected))
                    || GameState.Instance.IsThinking(nameof(ObstructionOfJusticeWillAddToYourPrisonTime))
                    || GameState.Instance.IsThinking(nameof(WontTurnYouInIfYouUnencryptThisDrive)));
        }
    }
}
