using System.Collections.Generic;
using SpaceResortMurder.Clues;
using SpaceResortMurder.Pathways;

namespace SpaceResortMurder.LocationsX
{
    public abstract class Location
    {
        public string Value { get; }
        public string Name { get; }
        public List<Clue> Clues { get; }
        public List<IPathway> Pathways { get; }

        protected Location(string location, string name, List<Clue> clues, List<IPathway> pathways)
        {
            Value = location;
            Name = name;
            Clues = clues;
            Pathways = pathways;
        }
    }
}
