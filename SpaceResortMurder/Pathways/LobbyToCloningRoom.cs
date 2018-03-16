using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogues.Zaid;
using SpaceResortMurder.LocationsX;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Pathways
{
    public class LobbyToCloningRoom : ExpandingImagePathway
    {
        public LobbyToCloningRoom() : base(
            nameof(LobbyToCloningRoom),
            "Placeholder/Door",
            new Transform2(new Vector2(350, 0), new Size2(350, 348)),
            nameof(TravissCloningRoom)) {}

        public override bool IsTraversible => CurrentGameState.IsThinking(nameof(WhoIsStayingAtYourResort));
    }
}
