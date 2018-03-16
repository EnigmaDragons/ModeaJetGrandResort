using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.Pathways
{
    public class LobbyToDockingBay : ExpandingImagePathway
    {
        public LobbyToDockingBay() : base(
            nameof(LobbyToDockingBay),
            "Placeholder/Door",
            new Transform2(new Vector2(0, 0), new Size2(350, 348)),
            nameof(DockingBay),
            "To Docking Bay") {}

        public override bool IsTraversible => true;
    }
}
