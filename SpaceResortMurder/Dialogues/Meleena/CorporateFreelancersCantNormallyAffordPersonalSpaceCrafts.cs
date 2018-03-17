using SpaceResortMurder.Clues.DockingBay;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class CorporateFreelancersCantNormallyAffordPersonalSpaceCrafts : Dialogue
    {
        public CorporateFreelancersCantNormallyAffordPersonalSpaceCrafts() : base(nameof(CorporateFreelancersCantNormallyAffordPersonalSpaceCrafts)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(MeleenasShip)) && CurrentGameState.IsThinking(nameof(WhoAreYou));
        }
    }
}
