using System.Collections.Generic;
using SpaceResortMurder.Clues;
using SpaceResortMurder.Clues.RaymondsSpaceCraft;
using SpaceResortMurder.Pathways;

namespace SpaceResortMurder.LocationsX
{
    public class RaymondsShipInterior : Location
    {
        public RaymondsShipInterior() : base(nameof(RaymondsShipInterior), "Raymond's Space Craft", 
            new List<Clue>
            {
                new RaymondsCorpse(),
                new RaymondsPad(),
                new ShipsLogs(),
            }, 
            new List<Pathway> { new RaymondsShipToDockingBay() }) {}
    }
}
