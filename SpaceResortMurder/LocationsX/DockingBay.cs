using System.Collections.Generic;
using SpaceResortMurder.Clues;
using SpaceResortMurder.Clues.DockingBay;
using SpaceResortMurder.Pathways;

namespace SpaceResortMurder.LocationsX
{
    public class DockingBay : Location
    {
        public DockingBay() : base(nameof(DockingBay), "Docking Bay", 
            new List<Clue>
            {
                new RaymondsShip(),
                new MeleenasShip(),
                new GarbageAirlock(),
            }, 
            new List<IPathway>
            {
                new DockingBayToLobby(),
                new DockingBayToRaymondsShip(),
                new DockingBayToMeleenasShip(),
                new DockingBayToPoliceCruiser(),
            }) {}
    }
}