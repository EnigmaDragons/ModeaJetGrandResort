using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.Pathways
{
    public class RaymondsShipToDockingBay : ExpandingImagePathway
    {
        public RaymondsShipToDockingBay() : base(
            nameof(RaymondsShipToDockingBay),
            "Placeholder/Door",
            new Transform2(new Vector2(0, 0), new Size2(350, 348)),
            nameof(DockingBay)) {}

        public override bool IsTraversible => true;
    }
}
