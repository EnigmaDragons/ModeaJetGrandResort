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
            return CurrentGameState.Instance.IsThinking(nameof(MeleenasShip))
                && !(CurrentGameState.Instance.IsThinking(nameof(HackingRig))
                    || CurrentGameState.Instance.IsThinking(nameof(DataStick))
                    || CurrentGameState.Instance.IsThinking(nameof(SkeletonKey)));
        }
    }
}
