namespace SpaceResortMurder.LocationsX
{
    public class RaymondsShipInteriorScene : LocationScene
    {
        public RaymondsShipInteriorScene() : base(
            GameObjects.Locations[nameof(RaymondsShipInterior)], 
            "Locations/Raymonds_spacecraft_interior") {}

        protected override void OnInit() {}
    }
}
