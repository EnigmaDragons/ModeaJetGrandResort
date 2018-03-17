using SpaceResortMurder.Clues.MeleenasSpaceCraft;
using SpaceResortMurder.Clues.RaymondsSpaceCraft;
using SpaceResortMurder.Clues.VacantRoom;
using SpaceResortMurder.Deductions;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class MeleenaYouShotTheShip : Dialogue
    {
        public MeleenaYouShotTheShip() : base(nameof(MeleenaYouShotTheShip)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(MeleenaShotRaymondsShip)) 
                && CurrentGameState.IsThinking(nameof(SkeletonKey)) 
                && CurrentGameState.IsThinking(nameof(T71EnergyBlaster));
        }
    }
}
