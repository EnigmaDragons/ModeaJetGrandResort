using System.Collections.Generic;
using SpaceResortMurder.Clues;
using SpaceResortMurder.Pathways;

namespace SpaceResortMurder.LocationsX
{
    public class Lobby : Location
    {
        public Lobby() : base(nameof(Lobby), "Lobby", new List<Clue>(), 
            new List<Pathway>
            {
                new LobbyToDockingBay(),
                new LobbyToCloningRoom(),
                new LobbyToVacantRoom(),
            }) {}
    }
}
