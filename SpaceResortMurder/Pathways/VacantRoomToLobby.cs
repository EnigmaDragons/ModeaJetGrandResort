using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Clues.VacantRoom;
using SpaceResortMurder.LocationsX;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Pathways
{
    public class VacantRoomToLobby : LightUpPathway
    {
        public VacantRoomToLobby(Transform2 transform) 
            : base(transform, nameof(Lobby), "Traverse/HotelRoomDoor", "To Lobby") {}

        public override bool IsTraversible => CurrentGameState.IsThinking(nameof(T71EnergyBlaster));
    }
}
