using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.LocationsX
{
    public class MeleenasShipInteriorScene : LocationScene
    {
        public MeleenasShipInteriorScene() : base(GameObjects.Locations[nameof(MeleenasShipInterior)]) {}

        protected override void OnInit()
        {
            Audio.PlayMusic("HackerSpaceship", 0.28f);
        }

        protected override void DrawBackground()
        {
            UI.FillScreen("Placeholder/MeleenasSpaceCraft");
        }
    }
}
