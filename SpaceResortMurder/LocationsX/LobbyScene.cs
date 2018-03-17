using MonoDragons.Core.AudioSystem;

namespace SpaceResortMurder.LocationsX
{
    public class LobbyScene : LocationScene
    {
        public LobbyScene() : base(GameObjects.Locations[nameof(Lobby)]) {}

        protected override void OnInit()
        {
            Audio.PlayMusic("HotelLobby", 0.98f);
        }
    }
}
