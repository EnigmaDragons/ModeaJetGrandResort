using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.Pathways
{
    public sealed class DockingBayToMeleenasShip : TraverseArrowPathway
    {
        public DockingBayToMeleenasShip(Transform2 transform, string traverseArrowType)
            : base(transform, nameof(MeleenasShipInterior), "To Modded Craft", traverseArrowType) { }

        public override bool IsTraversible => false;
    }
}
