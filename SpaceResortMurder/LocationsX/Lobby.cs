using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Clues;
using SpaceResortMurder.Pathways;
using System.Collections.Generic;

namespace SpaceResortMurder.LocationsX
{
    public class Lobby : Location
    {
        public Lobby() : base(nameof(Lobby),
            "Lobby",
            "Locations/lobby_final",
            new List<Clue>(),
            new List<IPathway>
            {
                new LobbyToDockingBay(new Transform2(new Vector2(912, 950), new Size2(96, 96)), "GreenD"),
                new LobbyToCloningRoom(new Transform2(new Vector2(723, 447), new Size2(376, 216))),
                new LobbyToVacantRoom(new Transform2(new Vector2(321, 443), new Size2(161, 405))),
            })
        { }
    }
}
