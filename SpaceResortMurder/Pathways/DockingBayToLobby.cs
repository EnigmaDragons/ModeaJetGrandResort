using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Clues.RaymondsSpaceCraft;
using SpaceResortMurder.LocationsX;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Pathways
{
    public class DockingBayToLobby : Pathway
    {
        public DockingBayToLobby() : base(
            nameof(DockingBayToLobby), 
            "Placeholder/Door", 
            new Transform2(new Vector2(0, 0), new Size2(350, 348)), 
            nameof(Lobby)) {}

        public override bool IsTraversible()
        {
            return CurrentGameState.IsThinking(nameof(RaymondsCorpse));
        }
    }
}
