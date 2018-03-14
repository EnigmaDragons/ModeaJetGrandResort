using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.LocationsX
{
    public class VacantRoomScene : LocationScene
    {
        public VacantRoomScene() : base(GameObjects.Locations[nameof(VacantRoom)]) {}

        protected override void OnInit() {}

        protected override void DrawBackground()
        {
            UI.FillScreen("Locations/BedroomBg");
        }
    }
}
