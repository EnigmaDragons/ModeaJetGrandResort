using MonoDragons.Core.AudioSystem;

namespace SpaceResortMurder.LocationsX
{
    public class RaymondsShipInteriorScene : LocationScene
    {
        public RaymondsShipInteriorScene() : base(
            GameObjects.Locations[nameof(RaymondsShipInterior)]) {}

        protected override void OnInit()
        {
            Audio.PlayMusic("RaymondShip");
        }
    }
}
