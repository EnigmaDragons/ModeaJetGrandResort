using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Clues.DockingBay
{
    public class RaymondsShip : Clue
    {
        public RaymondsShip(Transform2 transform) : base(
            "Clues/RaymondsShip",
            "Clues/RaymondsShip-Medium",
            transform, 
            new Size2(361, 327), 
            nameof(RaymondsShip),
            "Raymond's Craft") {}
    }
}
