using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogues.Zaid;
using SpaceResortMurder.LocationsX;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Pathways
{
    public sealed class LobbyToCloningRoom : LightUpPathway
    {
        public override bool IsTraversible => CurrentGameState.IsThinking(nameof(WhoIsStayingAtYourResort));

        public LobbyToCloningRoom(Transform2 transform) 
            : base(transform, nameof(TravissCloningRoom), "Traverse/LobbyDoor2", "To Travis's Room") { }
    }
}
