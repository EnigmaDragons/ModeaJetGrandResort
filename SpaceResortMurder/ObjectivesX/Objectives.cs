using SpaceResortMurder.State;
using System.Collections.Generic;
using System.Linq;

namespace SpaceResortMurder.ObjectivesX
{
    public class Objectives
    {
        private readonly List<Objective> _objectives = new List<Objective>();

        public void Init()
        {
            _objectives.Add(new LookAroundForClues());
            _objectives.Add(new AnswerADilemma());
            _objectives.Add(new InvestigateRaymondsShip());
            _objectives.Add(new InvestigateMeleenasCraft());
            _objectives.Add(new GoFindOutTheManagersAccount());
            _objectives.Add(new QuestionTravis());
            _objectives.Add(new FindRaymondsClone());
            _objectives.Add(new GetRaymondsCloneToAdmitHesAClone());
            _objectives.Add(new CheckWithWarrenForASearchOrder());

            _objectives.Add(new GetAnEncryptionKeyForMeleenasDataDrive());
            _objectives.Add(new CheckWhatsOnMeleenasDataDrive());
        }

        public IReadOnlyList<Objective> GetActiveObjectives()
        {
            return _objectives.Where(x => x.IsActive() && CurrentGameState.ShowObjectives).ToList();
        }
    }
}
