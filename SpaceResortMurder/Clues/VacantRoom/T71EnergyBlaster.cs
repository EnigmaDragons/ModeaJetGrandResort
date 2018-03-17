using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Clues.VacantRoom
{
    public class T71EnergyBlaster : Clue
    {
        public T71EnergyBlaster(Transform2 transform) : base(
            "Clues/SmokingBlaster-Medium", 
            transform, 
            new Size2(330, 330), 
            nameof(T71EnergyBlaster),
            "T71 Energy Blaster") {}
    }
}
