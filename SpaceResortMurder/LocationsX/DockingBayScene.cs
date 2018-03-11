using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Clues;

namespace SpaceResortMurder.LocationsX
{
    public class DockingBayScene : LocationScene
    {
        public DockingBayScene() : base(nameof(DockingBay)) {}

        protected override void OnInit()
        {
            _visuals.Add(new ImageBox { Image = "Placeholder/DockingBay", Transform = new Transform2(new Size2(1600, 900)) });
            AddClue(new RaymondsShip());
            AddClue(new MeleenasShip());
            AddClue(new PoliceCruiser());
            AddClue(new GarbageAirlock());
        }
    }
}
