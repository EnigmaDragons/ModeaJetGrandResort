using System.Collections.Generic;
using SpaceResortMurder.Clues;
using SpaceResortMurder.Clues.MeleenasSpaceCraft;
using SpaceResortMurder.Pathways;

namespace SpaceResortMurder.LocationsX
{
    public class MeleenasShipInterior : Location
    {
        public MeleenasShipInterior() : base(nameof(MeleenasShipInterior), "Meleena's Space Craft", 
            new List<Clue>
            {
                new DataStick(),
                new UnencryptedDataStick(),
                new SkeletonKey(),
                new HackingRig(),
            }, 
            new List<Pathway> { new MeleenasShipToDockingBay() }) {}
    }
}