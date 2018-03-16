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
                new LobbyToDockingBay(new Transform2(new Vector2(1764, 950), new Size2(96, 96)), "GreenR"),
                new LobbyToCloningRoom(new Transform2(new Vector2(980, 500), new Size2(96, 96)), "GreenU"),
                new LobbyToVacantRoom(new Transform2(new Vector2(780, 500), new Size2(96, 96)), "GreenU"),
            })
        { }
    }
}
