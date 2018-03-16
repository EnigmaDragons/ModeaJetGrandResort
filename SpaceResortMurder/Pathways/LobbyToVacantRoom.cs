using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogues.Travis;
using SpaceResortMurder.LocationsX;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Pathways
{
    public class LobbyToVacantRoom : ExpandingImagePathway
    {
        public LobbyToVacantRoom() : base(
            nameof(LobbyToVacantRoom),
            "Placeholder/Door",
            new Transform2(new Vector2(700, 0), new Size2(350, 348)),
            nameof(VacantRoom),
            "") {}

        public override bool IsTraversible => CurrentGameState.IsThinking(nameof(WhereIsYourClone));
    }
}
