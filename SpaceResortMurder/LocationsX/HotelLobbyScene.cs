using MonoDragons.Core.AudioSystem;
using SpaceResortMurder.Scenes;

namespace SpaceResortMurder.LocationsX
{
    public sealed class HotelLobbyScene : LocationScene
    {
        public HotelLobbyScene() 
            : base(nameof(HotelLobbyScene)) { }

        protected override void OnInit()
        {
            Audio.PlayMusicOnce("HotelLobby");
        }
    }
}
