using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.LocationsX
{
    public sealed class DockingBayScene : LocationScene
    {
        public DockingBayScene() : base(GameObjects.Locations[nameof(DockingBay)]) {}

        protected override void OnInit()
        {
            Audio.PlayMusic("DockingBay", 0.20f);
        }

        protected override void DrawBackground()
        {
            UI.FillScreen("Placeholder/DockingBay");
        }
    }
}
