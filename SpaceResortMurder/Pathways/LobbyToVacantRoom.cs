using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.Pathways
{
    public class LobbyToVacantRoom : Pathway
    {
        public LobbyToVacantRoom() : base(
            nameof(LobbyToVacantRoom),
            "Placeholder/Door",
            new Transform2(new Vector2(700, 0), new Size2(620, 348)),
            nameof(VacantRoom)) {}

        public override bool IsTraversible()
        {
            return true;
        }
    }
}
