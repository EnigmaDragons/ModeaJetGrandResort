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
            return CurrentGameState.Instance.IsThinking(nameof(DataStick))
                && !(CurrentGameState.Instance.IsThinking(nameof(CareToShowTheDirtYouCollected))
                    || CurrentGameState.Instance.IsThinking(nameof(ObstructionOfJusticeWillAddToYourPrisonTime))
                    || CurrentGameState.Instance.IsThinking(nameof(WontTurnYouInIfYouUnencryptThisDrive)));
        }
    }
}
