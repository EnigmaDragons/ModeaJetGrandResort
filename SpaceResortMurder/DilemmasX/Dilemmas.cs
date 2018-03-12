using System.Collections.Generic;
using System.Linq;

namespace SpaceResortMurder.DilemmasX
{
    public class Dilemmas
    {
        private List<Dilemma> _dilemmas = new List<Dilemma>()
        {
            new WhoShotRaymondsShip(),
            new WhatWasTheCauseOfDeath(),
            new WhoHackedTheDoor(),
            new WhereDidHeEnterSpaceFrom(),
            new WasZaidsResortAcceptedAsABetaTester(),
            new WhoWasTheMurderer(),
            new WasMeleenaTellingTheTruthAboutWhatHappenedOnRaymondsShip(),
        };

        public IReadOnlyList<Dilemma> GetActiveDilemmas()
        {
            return _dilemmas.Where(d => d.IsActive()).ToList();
        }

        public void Init()
        {
            _dilemmas.ForEach(d => d.Init());
        }
    }
}
