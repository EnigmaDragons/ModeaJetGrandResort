using System.Collections.Generic;
using SpaceResortMurder.Clues;
using SpaceResortMurder.Clues.PoliceSpaceCraft;
using SpaceResortMurder.Pathways;

namespace SpaceResortMurder.LocationsX
{
    public class PoliceCruiserInterior : Location
    {
        public PoliceCruiserInterior() : base(nameof(PoliceCruiserInterior), "Police Cruiser", 
            new List<Clue> { new Clock() }, 
            new List<Pathway> { new PoliceCruiserToDockingBay() }) {}
    }
}
