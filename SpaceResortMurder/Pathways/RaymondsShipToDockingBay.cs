using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Clues.RaymondsSpaceCraft;
using SpaceResortMurder.LocationsX;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Pathways
{
    public sealed class RaymondsShipToDockingBay : LightUpPathway
    {
        public RaymondsShipToDockingBay(Transform2 transform) 
            : base(transform, 
                nameof(DockingBay), 
                "Traverse/RaymondShuttleExit", 
                "To Docking Bay") { }

        public override bool IsTraversible => CurrentGameState.IsThinking(nameof(RaymondsCorpse))
                && CurrentGameState.IsThinking(nameof(ShipsLogs))
                && CurrentGameState.IsThinking(nameof(RaymondsPad));
    }
}
