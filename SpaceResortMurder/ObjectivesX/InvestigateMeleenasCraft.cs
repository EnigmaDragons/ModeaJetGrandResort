using SpaceResortMurder.Clues.DockingBay;
using SpaceResortMurder.Clues.MeleenasSpaceCraft;
using SpaceResortMurder.State;

namespace SpaceResortMurder.ObjectivesX
{
    public class InvestigateMeleenasCraft : Objective
    {
        public InvestigateMeleenasCraft() : base(nameof(InvestigateMeleenasCraft)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(MeleenasShip))
                && !(CurrentGameState.IsThinking(nameof(HackingRig))
                    || CurrentGameState.IsThinking(nameof(EncryptedDataStick))
                    || CurrentGameState.IsThinking(nameof(SkeletonKey)));
        }
    }
}
