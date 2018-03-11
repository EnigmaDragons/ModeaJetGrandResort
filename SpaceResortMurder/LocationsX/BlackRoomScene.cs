using MonoDragons.Core.AudioSystem;
using SpaceResortMurder.Clues;

namespace SpaceResortMurder.LocationsX
{
    public class BlackRoomScene : LocationScene
    {
        public BlackRoomScene() : base(nameof(BlackRoom)) { }

        protected override void OnInit()
        {
            Audio.PlayMusic("HotelLobby");
            AddClue(new Necronomicon());
        }
    }
}
