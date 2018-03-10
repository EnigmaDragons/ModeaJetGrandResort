using System.Collections.Generic;
using System.Linq;

namespace SpaceResortMurder.DilemmaStuff
{
    public class Dilemmas
    {
        private List<Dilemma> dilemmas = new List<Dilemma>()
        {
            new WhoKilledRaymond(),
        };

        public IReadOnlyList<Dilemma> GetActiveDilemmas()
        {
            return dilemmas.Where(d => d.IsActive()).ToList();
        }

        public void Init()
        {
            dilemmas.ForEach(d => d.Init());
        }
    }
}
