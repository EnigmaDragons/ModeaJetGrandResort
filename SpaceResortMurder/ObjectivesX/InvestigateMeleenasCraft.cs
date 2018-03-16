using SpaceResortMurder.Clues.MeleenasSpaceCraft;
using SpaceResortMurder.Dialogues.Meleena;
using SpaceResortMurder.State;

namespace SpaceResortMurder.ObjectivesX
{
    public class InvestigateMeleenasCraft : Objective
    {
        public InvestigateMeleenasCraft() : base(nameof(InvestigateMeleenasCraft)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(HereIsTheSearchOrder))
                && !(CurrentGameState.IsThinking(nameof(HackingRig))
                    && CurrentGameState.IsThinking(nameof(EncryptedDataDrive))
                    && CurrentGameState.IsThinking(nameof(SkeletonKey)));
        }
    }
}
