using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogues.Zaid;
using SpaceResortMurder.LocationsX;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Pathways
{
    public sealed class LobbyToCloningRoom : TraverseArrowPathway
    {
        public LobbyToCloningRoom(Transform2 transform, string traverseArrowType)
            : base(transform, nameof(TravissCloningRoom), "To Travis's Room", traverseArrowType) { }

        public override bool IsTraversible => CurrentGameState.IsThinking(nameof(WhoIsStayingAtYourResort));
    }
}
