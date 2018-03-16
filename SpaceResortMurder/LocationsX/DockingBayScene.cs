using MonoDragons.Core.AudioSystem;

namespace SpaceResortMurder.LocationsX
{
    public sealed class DockingBayScene : LocationScene
    {
        public DockingBayScene() : base(GameObjects.Locations[nameof(DockingBay)]) {}

        protected override void OnInit()
        {
            Audio.PlayMusic("DockingBay", 0.20f);
        }
    }
}
