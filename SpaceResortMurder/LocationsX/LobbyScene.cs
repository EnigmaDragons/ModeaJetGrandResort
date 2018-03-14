using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Pathways;

namespace SpaceResortMurder.LocationsX
{
    public class LobbyScene : LocationScene
    {
        public LobbyScene() : base(nameof(Lobby)) {}

        protected override string Name => "Hotel Lobby";

        protected override void OnInit()
        {
            Audio.PlayMusic("HotelLobby");
            AddPathway(new LobbyToDockingBay());
            AddPathway(new LobbyToCloningRoom());
            AddPathway(new LobbyToVacantRoom());
        }

        protected override void DrawBackground()
        {
            UI.FillScreen("Locations/hotel_lobby_environment");
        }
    }
}
