using SpaceResortMurder.Dialogues.RaymondsClone;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.ElectricalBurnsComeFrom
{
    public class ACloningMalfunction : Deduction
    {
        public ACloningMalfunction() : base(nameof(ACloningMalfunction)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(ElectricDischarge));
        }
    }
}
