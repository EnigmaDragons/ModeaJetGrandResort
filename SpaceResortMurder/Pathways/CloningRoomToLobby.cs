using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Clues.CloningRoom;
using SpaceResortMurder.LocationsX;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Pathways
{
    public sealed class CloningRoomToLobby : TraverseArrowPathway
    {
        public CloningRoomToLobby(Transform2 transform, string traverseArrowType)
            : base(transform, nameof(Lobby), "To Lobby", traverseArrowType) { }

        public override bool IsTraversible => CurrentGameState.IsThinking(nameof(CloningChamber));
    }
}
