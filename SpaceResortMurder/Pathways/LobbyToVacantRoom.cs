using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogues.Travis;
using SpaceResortMurder.LocationsX;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Pathways
{
    public sealed class LobbyToVacantRoom : LightUpPathway
    {
        public override bool IsTraversible => CurrentGameState.IsThinking(nameof(WhereIsYourClone));

        public LobbyToVacantRoom(Transform2 transform) 
            : base(transform, nameof(VacantRoom), "Traverse/LobbyDoor1", "To Raymond's Room")
        {
        }
    }
}
