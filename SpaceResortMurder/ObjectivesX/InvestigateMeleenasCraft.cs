using SpaceResortMurder.Clues.DockingBay;
using SpaceResortMurder.Clues.MeleenasSpaceCraft;

namespace SpaceResortMurder.ObjectivesX
{
    public class InvestigateMeleenasCraft : Objective
    {
        public InvestigateMeleenasCraft() : base(nameof(InvestigateMeleenasCraft)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(MeleenasShip))
                && !(GameState.Instance.IsThinking(nameof(HackingRig))
                    || GameState.Instance.IsThinking(nameof(DataStick))
                    || GameState.Instance.IsThinking(nameof(SkeletonKey)));
        }
    }
}
