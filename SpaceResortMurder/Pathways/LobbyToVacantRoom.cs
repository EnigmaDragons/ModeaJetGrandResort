using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogues.Travis;
using SpaceResortMurder.LocationsX;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Pathways
{
    public sealed class LobbyToVacantRoom : TraverseArrowPathway
    {
        public LobbyToVacantRoom(Transform2 transform, string traverseArrowType)
            : base(transform, nameof(VacantRoom), "To Raymond's Room", traverseArrowType) { }

        public override bool IsTraversible => CurrentGameState.IsThinking(nameof(WhereIsYourClone));
    }
}
