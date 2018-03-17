using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Clues.DockingBay
{
    public class GarbageAirlock : Clue
    {
        public GarbageAirlock(Transform2 transform) : base(
            "Clues/GarbageAirlock", 
            transform, 
            new Size2(430, 330), 
            nameof(GarbageAirlock),
            "Airlock") {}
    }
}
