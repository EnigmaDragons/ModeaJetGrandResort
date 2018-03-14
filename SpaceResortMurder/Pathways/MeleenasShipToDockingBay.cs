using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.Pathways
{
    public class MeleenasShipToDockingBay : Pathway
    {
        public MeleenasShipToDockingBay() : base(
            nameof(MeleenasShipToDockingBay),
            "Placeholder/Door",
            new Transform2(new Vector2(0, 0), new Size2(620, 348)),
            nameof(DockingBay)) {}

        public override bool IsTraversible()
        {
            return true;
        }
    }
}
