using System.Collections.Generic;
using System.Linq;

namespace SpaceResortMurder.LocationsX
{
    public class Locations
    {
        private readonly List<Location> _locations = new List<Location>(); 

        public void Init()
        {
            _locations.Add(new DockingBay());
            _locations.Add(new Lobby());
            _locations.Add(new RaymondsShipInterior());
            _locations.Add(new MeleenasShipInterior());
            _locations.Add(new VacantRoom());
        }

        public IReadOnlyList<Location> GetAvailableLocations()
        {
            return _locations.Where(x => x.IsAvailable()).ToList();
        }
    }
}
