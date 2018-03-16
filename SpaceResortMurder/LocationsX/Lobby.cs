using System.Collections.Generic;
using SpaceResortMurder.Clues;
using SpaceResortMurder.Pathways;

namespace SpaceResortMurder.LocationsX
{
    public class Lobby : Location
    {
        public Lobby() : base(nameof(Lobby), "Lobby", "Locations/hotel_lobby_environment", 
            new List<Clue>(),
            new List<IPathway>
            {
                new LobbyToDockingBay(),
                new LobbyToCloningRoom(),
                new LobbyToVacantRoom(),
            }) {}
    }
}
