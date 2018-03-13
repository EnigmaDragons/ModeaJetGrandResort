using MonoDragons.Core.Common;
using System.Collections.Generic;
using System.Linq;

namespace SpaceResortMurder.CharactersX
{
    public class Characters
    {
        public IReadOnlyList<Character> People { get; } = new List<Character>() {
            new OfficerWarren(),
            new ResortManagerZaid(),
            new ResearcherTravis(),
            new HackerMeleena(),
            new RaymondsClone(),
        };

        public void Init()
        {
            People.ForEach(p => p.Init());
        }

        public IReadOnlyList<Character> GetPeopleAt(string location)
        {
            return People.Where(x => x.WhereAreYou() == location).ToList();
        }
    }
}
