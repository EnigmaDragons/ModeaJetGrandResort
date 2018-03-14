using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.LocationsX
{
    public class VacantRoomScene : LocationScene
    {
        public VacantRoomScene() : base(GameObjects.Locations[nameof(VacantRoom)], "Locations/BedroomBg") {}

        protected override void OnInit() {}
    }
}
