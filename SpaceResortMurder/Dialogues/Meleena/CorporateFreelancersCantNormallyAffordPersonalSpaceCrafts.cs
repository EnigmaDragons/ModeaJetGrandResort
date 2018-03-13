using SpaceResortMurder.Clues.DockingBay;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class CorporateFreelancersCantNormallyAffordPersonalSpaceCrafts : Dialogue
    {
        public CorporateFreelancersCantNormallyAffordPersonalSpaceCrafts() : base(nameof(CorporateFreelancersCantNormallyAffordPersonalSpaceCrafts)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(MeleenasShip));
        }
    }
}
