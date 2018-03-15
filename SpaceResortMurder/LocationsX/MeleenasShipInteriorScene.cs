using MonoDragons.Core.AudioSystem;

namespace SpaceResortMurder.LocationsX
{
    public class MeleenasShipInteriorScene : LocationScene
    {
        public MeleenasShipInteriorScene() : base(
            GameObjects.Locations[nameof(MeleenasShipInterior)], 
            "Locations/meleenas_spaceship_painted") {}

        protected override void OnInit()
        {
            Audio.PlayMusic("HackerSpaceship", 0.28f);
        }
    }
}
