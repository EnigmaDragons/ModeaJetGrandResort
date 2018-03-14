using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.Pathways
{
    public class DockingBayToRaymondsShip : Pathway
    {
        public DockingBayToRaymondsShip() : base(
            nameof(DockingBayToRaymondsShip),
            "Placeholder/Door",
            new Transform2(new Vector2(350, 0), new Size2(620, 348)),
            nameof(RaymondsShipInterior)) {}

        public override bool IsTraversible()
        {
            return true;
        }
    }
}
