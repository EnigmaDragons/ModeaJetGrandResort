using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.Pathways
{
    public class LobbyToDockingBay : TraverseArrowPathway
    {
        public LobbyToDockingBay(Transform2 transform, string traverseArrowType)
            : base(transform, nameof(DockingBay), "To Docking Bay", traverseArrowType) { }

        public override bool IsTraversible => true;
    }
}
