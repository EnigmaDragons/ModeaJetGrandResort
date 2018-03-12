using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Clues;

namespace SpaceResortMurder.LocationsX
{
    public sealed class DockingBayScene : LocationScene
    {
        public DockingBayScene() : base(nameof(DockingBay)) {}

        protected override string Name => "Docking Bay";

        protected override void OnInit()
        {
            AddClue(new RaymondsShip());
            AddClue(new MeleenasShip());
            AddClue(new PoliceCruiser());
            AddClue(new GarbageAirlock());
        }

        protected override void DrawBackground()
        {
            UI.FillScreen("Placeholder/DockingBay");
        }
    }
}
