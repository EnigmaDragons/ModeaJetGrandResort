using System.Collections.Generic;
using System.Linq;

namespace SpaceResortMurder.Characters
{
    public class People
    {
        private readonly List<Person> _people = new List<Person>();

        public void Init()
        {
            _people.Add(new PoliceOfficier());
            _people.Add(new ResortManagerZaid());
        }

        public IReadOnlyList<Person> GetPeopleAt(string location)
        {
            return _people.Where(x => x.WhereAreYou() == location).ToList();
        }
    }
}
