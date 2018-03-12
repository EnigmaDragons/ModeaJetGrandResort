using System.Collections.Generic;
using System.Linq;

namespace SpaceResortMurder.DilemmasX
{
    public class Dilemmas
    {
        private List<Dilemma> dilemmas = new List<Dilemma>()
        {
            new WhoShotRaymondsShip(),
            new WhatWasTheCauseOfDeath(),
            new WhoHackedTheDoor(),
            new WhereDidHeEnterSpaceFrom(),
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
