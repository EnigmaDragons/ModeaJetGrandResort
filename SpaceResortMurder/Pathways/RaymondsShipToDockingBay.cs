using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Clues.RaymondsSpaceCraft;
using SpaceResortMurder.LocationsX;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Pathways
{
    public class RaymondsShipToDockingBay : ExpandingImagePathway
    {
        public RaymondsShipToDockingBay() : base(
            nameof(RaymondsShipToDockingBay),
            "Placeholder/Door",
            new Transform2(new Vector2(0, 0), new Size2(350, 348)),
            nameof(DockingBay)) {}

        public override bool IsTraversible => CurrentGameState.IsThinking(nameof(RaymondsCorpse))
                && CurrentGameState.IsThinking(nameof(ShipsLogs))
                && CurrentGameState.IsThinking(nameof(RaymondsPad));
    }
}
