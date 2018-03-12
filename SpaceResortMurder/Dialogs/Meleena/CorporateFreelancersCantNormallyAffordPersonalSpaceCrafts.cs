using SpaceResortMurder.Clues.DockingBay;

namespace SpaceResortMurder.Dialogs.Meleena
{
    public class CorporateFreelancersCantNormallyAffordPersonalSpaceCrafts : Dialog
    {
        public CorporateFreelancersCantNormallyAffordPersonalSpaceCrafts() : base(nameof(CorporateFreelancersCantNormallyAffordPersonalSpaceCrafts)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(MeleenasShip));
        }

        public override bool IsImmediatelyStarted()
        {
            return false;
        }
    }
}
