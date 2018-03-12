using SpaceResortMurder.Clues.DockingBay;

namespace SpaceResortMurder.ObjectivesX
{
    public class InvestigateMeleenasCraft : Objective
    {
        public InvestigateMeleenasCraft() : base(nameof(InvestigateMeleenasCraft)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(MeleenasShip));
        }
    }
}
