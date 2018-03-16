using SpaceResortMurder.Clues;
using SpaceResortMurder.Pathways;
using System.Collections.Generic;
using SpaceResortMurder.Clues.RaymondsSpaceCraft;

namespace SpaceResortMurder.LocationsX
{
    public class VacantRoom : Location
    {
        public VacantRoom() : base(nameof(VacantRoom), "Vacant Resort Room", 
            new List<Clue> { new T71EnergyBlaster() }, 
            new List<Pathway> { new VacantRoomToLobby() }) {}
    }
}