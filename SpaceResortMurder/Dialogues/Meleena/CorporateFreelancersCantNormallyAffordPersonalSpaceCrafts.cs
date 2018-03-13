using SpaceResortMurder.Clues.DockingBay;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class CorporateFreelancersCantNormallyAffordPersonalSpaceCrafts : Dialogue
    {
        public CorporateFreelancersCantNormallyAffordPersonalSpaceCrafts() : base(nameof(CorporateFreelancersCantNormallyAffordPersonalSpaceCrafts)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(MeleenasShip));
        }
    }
}
