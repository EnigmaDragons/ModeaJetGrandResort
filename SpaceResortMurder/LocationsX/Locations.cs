﻿using System.Collections.Generic;
using System.Linq;

namespace SpaceResortMurder.LocationsX
{
    public class Locations
    {
        private readonly List<Location> _locations = new List<Location>(); 

        public void Init()
        {
            _locations.Add(new BlackRoom());
            _locations.Add(new SecondRoom());
        }

        public IReadOnlyList<Location> GetAvailableLocations()
        {
            return _locations.Where(x => x.IsAvailable()).ToList();
        }
    }
}
