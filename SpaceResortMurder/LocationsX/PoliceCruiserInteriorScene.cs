using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.LocationsX
{
    public class PoliceCruiserInteriorScene : LocationScene
    {
        public PoliceCruiserInteriorScene() : base(GameObjects.Locations[nameof(PoliceCruiserInterior)]) {}

        protected override void OnInit() {}

        protected override void DrawBackground()
        {
            UI.FillScreen("Placeholder/PoliceCruiser");
        }
    }
}
