using MonoDragons.Core.AudioSystem;

namespace SpaceResortMurder.LocationsX
{
    public class VacantRoomScene : LocationScene
    {
        public VacantRoomScene() : base(GameObjects.Locations[nameof(VacantRoom)]) {}

        protected override void OnInit()
        {
            Audio.PlayMusic("VacantRoom");
        }
    }
}
