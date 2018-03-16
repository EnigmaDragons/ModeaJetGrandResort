using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.Pathways
{
    public class DockingBayToMeleenasShip : ExpandingImagePathway
    {
        public DockingBayToMeleenasShip() : base(
            nameof(DockingBayToMeleenasShip),
            "Placeholder/Door",
            new Transform2(new Vector2(700, 0), new Size2(350, 348)),
            nameof(MeleenasShipInterior)) {}

        public override bool IsTraversible =>  false;
    }
}
