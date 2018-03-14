using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogues.Warren;
using SpaceResortMurder.LocationsX;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Pathways
{
    public class PoliceCruiserToDockingBay : Pathway
    {
        public PoliceCruiserToDockingBay() : base(
            nameof(PoliceCruiserToDockingBay), 
            "Placeholder/Door", 
            new Transform2(new Vector2(0, 0), new Size2(350, 348)), 
            nameof(DockingBay)) {}

        public override bool IsTraversible()
        {
            return CurrentGameState.Instance.IsThinking(nameof(BetweenSevenAMToEightPM));
        }
    }
}
