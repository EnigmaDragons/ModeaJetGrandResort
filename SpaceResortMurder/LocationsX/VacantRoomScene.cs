using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Pathways;

namespace SpaceResortMurder.LocationsX
{
    public class VacantRoomScene : LocationScene
    {
        protected override string Name => "Vacant Resort Room";

        public VacantRoomScene() : base(nameof(VacantRoom)) {}

        protected override void OnInit()
        {
            AddPathway(new VacantRoomToLobby());
        }

        protected override void DrawBackground()
        {
            UI.FillScreen("Locations/BedroomBg");
        }
    }
}
