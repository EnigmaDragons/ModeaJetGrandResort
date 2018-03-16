using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.LocationsX
{
    public class LobbyScene : LocationScene
    {
        public LobbyScene() : base(GameObjects.Locations[nameof(Lobby)]) {}

        protected override void OnInit()
        {
            Audio.PlayMusic("HotelLobby");
        }
    }
}
