using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.Pathways
{
    public class CloningRoomToLobby : Pathway
    {
        public CloningRoomToLobby() : base(
            nameof(CloningRoomToLobby),
            "Placeholder/Door",
            new Transform2(new Vector2(0, 0), new Size2(620, 348)),
            nameof(Lobby)) {}

        public override bool IsTraversible()
        {
            return true;
        }
    }
}
