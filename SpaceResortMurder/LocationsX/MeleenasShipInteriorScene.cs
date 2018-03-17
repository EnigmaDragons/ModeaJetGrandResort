using MonoDragons.Core.AudioSystem;

namespace SpaceResortMurder.LocationsX
{
    public class MeleenasShipInteriorScene : LocationScene
    {
        public MeleenasShipInteriorScene() : base(
            GameObjects.Locations[nameof(MeleenasShipInterior)]) {}

        protected override void OnInit()
        {
            Audio.PlayMusic("HackerSpaceship", 0.52f);
        }
    }
}
