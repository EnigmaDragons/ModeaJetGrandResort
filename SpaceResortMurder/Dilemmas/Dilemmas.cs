using System.Collections.Generic;
using System.Linq;

namespace SpaceResortMurder.Pondering
{
    public class Dilemmas
    {
        private List<Dilemma> dilemmas = new List<Dilemma>()
        {
            new WhoKilledRaymondDilemma(),
        };

        public IReadOnlyList<Dilemma> GetActiveDilemmas()
        {
            return dilemmas.Where(d => d.IsActive()).ToList();
        }
    }
}
