using SpaceResortMurder.Clues.CloningRoom;
using SpaceResortMurder.Clues.MeleenasSpaceCraft;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Travis
{
    public class ViolentExperimentalResearch : Dialogue
    {
        public ViolentExperimentalResearch() : base(nameof(ViolentExperimentalResearch)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(CloningChamber))
                   && CurrentGameState.Instance.IsThinking(nameof(UnencryptedDataStick));
        }
    }
}
