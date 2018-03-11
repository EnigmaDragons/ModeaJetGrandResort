using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Clues;

namespace SpaceResortMurder.LocationsX
{
    public class BlackRoomScene : LocationScene
    {
        public BlackRoomScene() : base(nameof(BlackRoom)) { }

        protected override void OnInit()
        {
            Audio.PlayMusic("HotelLobby");
        }

        protected override void DrawBackground()
        {
            UI.FillScreen("Locations/BedroomBg");
        }
    }
}
