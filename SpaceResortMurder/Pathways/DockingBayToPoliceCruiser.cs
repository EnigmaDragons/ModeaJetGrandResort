using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Clues.RaymondsSpaceCraft;
using SpaceResortMurder.LocationsX;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Pathways
{
    public class DockingBayToPoliceCruiser : TraverseArrowPathway
    {
        public DockingBayToPoliceCruiser(Transform2 transform, string traverseArrowType) 
            : base(transform, nameof(PoliceCruiserInterior), "To Police Cruiser", traverseArrowType) { }

        public override bool IsTraversible => CurrentGameState.IsThinking(nameof(RaymondsCorpse));
    }
}
