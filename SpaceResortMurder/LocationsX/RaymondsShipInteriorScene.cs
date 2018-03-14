using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.LocationsX
{
    public class RaymondsShipInteriorScene : LocationScene
    {
        public RaymondsShipInteriorScene() : base(GameObjects.Locations[nameof(RaymondsShipInterior)]) {}

        protected override void OnInit() {}

        protected override void DrawBackground()
        {
            UI.FillScreen("Placeholder/RaymondsShip");
        }
    }
}
