using System.Collections.Generic;
using System.Linq;

namespace SpaceResortMurder.CharactersX
{
    public class Characters
    {
        private readonly List<Character> _people = new List<Character>() {
            new OfficerWarren(),
            new ResortManagerZaid(),
            new ResearcherTravis(),
            new HackerMeleena(),
        };

        public IReadOnlyList<Character> GetPeopleAt(string location)
        {
            return _people.Where(x => x.WhereAreYou() == location).ToList();
        }
    }
}
