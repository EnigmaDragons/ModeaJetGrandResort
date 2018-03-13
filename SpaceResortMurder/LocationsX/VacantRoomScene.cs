using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.LocationsX
{
    public class VacantRoomScene : LocationScene
    {
        protected override string Name => "Vacant Resort Room";

        public VacantRoomScene() : base(nameof(VacantRoom)) {}

        protected override void OnInit() {}

        protected override void DrawBackground()
        {
            UI.FillScreen("Locations/BedroomBg");
        }
    }
}
