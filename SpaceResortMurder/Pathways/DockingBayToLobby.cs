using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Clues.RaymondsSpaceCraft;
using SpaceResortMurder.Dialogues.Meleena;
using SpaceResortMurder.LocationsX;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Pathways
{
    public class DockingBayToLobby : LightUpPathway
    {
        public DockingBayToLobby(Transform2 transform) 
            : base(transform, nameof(Lobby), "Traverse/DockingBayToLobbyDoor", "To Lobby") { }

        public override bool IsTraversible =>  CurrentGameState.IsThinking(nameof(RaymondsCorpse)) && CurrentGameState.IsThinking(nameof(WhoAreYou));
    }
}
