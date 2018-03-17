
using MonoDragons.Core.AudioSystem;

namespace SpaceResortMurder.LocationsX
{
    public class TravissCloningRoomScene : LocationScene
    {
        public TravissCloningRoomScene() : base(
            GameObjects.Locations[nameof(TravissCloningRoom)]) {}

        protected override void OnInit()
        {
            Audio.PlayMusic("CloningRoom", 0.94f);
        }
    }
}
