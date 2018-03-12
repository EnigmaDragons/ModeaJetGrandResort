using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.LocationsX
{
    public class LobbyScene : LocationScene
    {
        public LobbyScene() : base(nameof(Lobby)) {}

        protected override string Name => "Hotel Lobby";

        protected override void OnInit()
        {
            Audio.PlayMusicOnce("HotelLobby");
        }

        protected override void DrawBackground()
        {
            UI.FillScreen("Locations/hotel_lobby_environment");
        }
    }
}
