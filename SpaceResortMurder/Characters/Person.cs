using System.Collections.Generic;
using System.Linq;
using SpaceResortMurder.Dialogs;

namespace SpaceResortMurder.Characters
{
    public abstract class Person
    {
        private readonly List<Dialog> _dialogs;

        protected Person(params Dialog[] dialogs)
        {
            _dialogs = dialogs.ToList();
        }

        public IReadOnlyList<Dialog> GetDialogs()
        {
            return _dialogs.Where(x => x.IsActive()).OrderBy(x => x.IsExplored).ToList();
        }
    }
}
