using System.Collections.Generic;

namespace SpaceResortMurder.LocationsX
{
    public class Locations
    {
        public Location this[string name] => _locations[name];

        private readonly Dictionary<string, Location> _locations = new Dictionary<string, Location>
        {
            { nameof(DockingBay), new DockingBay() },
            { nameof(Lobby), new Lobby() },
            { nameof(RaymondsShipInterior), new RaymondsShipInterior() },
            { nameof(MeleenasShipInterior), new MeleenasShipInterior() },
            { nameof(VacantRoom), new VacantRoom() },
            { nameof(TravissCloningRoom), new TravissCloningRoom() },
            { nameof(PoliceCruiserInterior), new PoliceCruiserInterior() },
        }; 
    }
}
