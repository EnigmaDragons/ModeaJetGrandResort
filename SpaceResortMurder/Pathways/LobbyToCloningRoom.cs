using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.Pathways
{
    public class LobbyToCloningRoom : Pathway
    {
        public LobbyToCloningRoom() : base(
            nameof(LobbyToCloningRoom),
            "Placeholder/Door",
            new Transform2(new Vector2(350, 0), new Size2(350, 348)),
            nameof(TravissCloningRoom)) {}

        public override bool IsTraversible()
        {
            return true;
        }
    }
}
