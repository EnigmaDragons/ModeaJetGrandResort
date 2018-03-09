using System.Collections.Generic;
using MonoDragons.Core.EventSystem;

namespace SpaceResortMurder.Pondering
{
    public class Dilemmas
    {
        private readonly List<IDilemma> _list = new List<IDilemma>();
        public IReadOnlyList<IDilemma> List => _list.AsReadOnly();

        public void Init()
        {
            Event.SubscribeForever(EventSubscription.Create<DilemmaGained>(x => _list.Add(x.Dilemma), this));
            Event.SubscribeForever(EventSubscription.Create<DilemmaLost>(x => _list.Remove(x.Dilemma), this));
            new WhoKilledRaymondDilemma().Init();
        }
    }
}
