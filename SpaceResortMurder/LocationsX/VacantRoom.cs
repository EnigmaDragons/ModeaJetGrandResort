using SpaceResortMurder.Clues;
using SpaceResortMurder.Pathways;
using System.Collections.Generic;

namespace SpaceResortMurder.LocationsX
{
    public class VacantRoom : Location
    {
        public VacantRoom() : base(nameof(VacantRoom), "Vacant Resort Room", new List<Clue>(), 
            new List<Pathway> { new VacantRoomToLobby() }) {}
    }
}