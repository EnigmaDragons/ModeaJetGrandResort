using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.Pathways
{
    public class DockingBayToRaymondsShip : TraverseArrowPathway
    {
        public DockingBayToRaymondsShip(Transform2 transform, string traverseArrowType)
            : base(transform, nameof(RaymondsShipInterior), "To Raymond's Craft", traverseArrowType) { }

        public override bool IsTraversible => true;

    }
}
