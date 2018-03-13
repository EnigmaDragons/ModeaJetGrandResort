using System.Collections.Generic;
using System.Linq;

namespace SpaceResortMurder.ObjectivesX
{
    public class Objectives
    {
        private readonly List<Objective> _objectives = new List<Objective>();

        public void Init()
        {
            _objectives.Add(new InvestigateRaymondsDeadBody());
            _objectives.Add(new InvestigateMeleenasCraft());
            _objectives.Add(new GetAnEncryptionKeyForMeleenasDataStick());
            _objectives.Add(new CheckWhatsOnMeleenasDataStick());
        }

        public IReadOnlyList<Objective> GetActiveObjectives()
        {
            return _objectives.Where(x => x.IsActive()).ToList();
        }
    }
}
