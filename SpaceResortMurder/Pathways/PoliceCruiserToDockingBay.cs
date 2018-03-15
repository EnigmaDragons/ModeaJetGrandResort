using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogues.Warren;
using SpaceResortMurder.LocationsX;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Pathways
{
    public class PoliceCruiserToDockingBay : Pathway
    {
        public PoliceCruiserToDockingBay(Transform2 transform) : base(
            nameof(PoliceCruiserToDockingBay), 
            "Placeholder/TravelArrow", 
            transform, 
            nameof(DockingBay)) {}

        public override bool IsTraversible()
        {
            return CurrentGameState.IsThinking(nameof(BetweenSevenAMToEightPM));
        }
    }
}
