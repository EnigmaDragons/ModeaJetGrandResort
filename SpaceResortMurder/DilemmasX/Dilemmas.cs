using System.Collections.Generic;
using System.Linq;
using SpaceResortMurder.DilemmasX.CoreDilemmas;

namespace SpaceResortMurder.DilemmasX
{
    public class Dilemmas
    {
        private List<Dilemma> _coreDilemmas = new List<Dilemma>
        {
            new WhoWasTheMurderer(),
            new WhatWasTheCauseOfDeath(),
            new WhatWasTheCulpritsMotive(),
        };

        private List<Dilemma> _dilemmas = new List<Dilemma>
        {
            new WasZaidsResortAcceptedAsABetaTester(),
            new WhereDidRaymondsCloneGetAnElectricalBurn(),
            new WhatWasTheTimeFrameForTheMurder(),
            new WhoHackedTheDoor(),
            new WhereDidTheBruisesComeFrom(),
            new WhoLaunchedTheShip(),
            new WhoShotRaymondsShip(),
            new WasTheCloneDesignedToKill(),
        };

        public bool HasTheory => _coreDilemmas.All(d => d.HasAnswerSelected);

        public IReadOnlyList<Dilemma> GetActiveDilemmas()
        {
            return _dilemmas.Where(d => d.IsActive()).Concat(_coreDilemmas.Where(d => d.IsActive())).ToList();
        }

        public void Init()
        {
            _dilemmas.ForEach(d => d.Init());
            _coreDilemmas.ForEach(d => d.Init());
        }
    }
}
