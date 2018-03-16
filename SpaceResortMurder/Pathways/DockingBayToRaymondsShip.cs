using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.Pathways
{
    public class DockingBayToRaymondsShip : ExpandingImagePathway
    {
        public DockingBayToRaymondsShip() : base(
            nameof(DockingBayToRaymondsShip),
            "Placeholder/Door",
            new Transform2(new Vector2(350, 0), new Size2(350, 348)),
            nameof(RaymondsShipInterior),
            "To Raymond's Craft") {}

        public override bool IsTraversible => true;
    }
}
