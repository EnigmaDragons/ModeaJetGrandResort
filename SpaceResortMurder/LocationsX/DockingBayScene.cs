using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Clues;
using SpaceResortMurder.Clues.DockingBay;
using SpaceResortMurder.Pathways;
using SpaceResortMurder.State;

namespace SpaceResortMurder.LocationsX
{
    public sealed class DockingBayScene : LocationScene
    {
        public DockingBayScene() : base(nameof(DockingBay)) {}

        protected override string Name => "Docking Bay";

        protected override void OnInit()
        {
            Audio.PlayMusic("DockingBay", 0.20f);
            AddClue(new RaymondsShip());
            AddClue(new MeleenasShip());
            AddClue(new PoliceCruiser());
            AddClue(new GarbageAirlock());
            AddPathway(new DockingBayToLobby());
            AddPathway(new DockingBayToRaymondsShip());
            AddPathway(new DockingBayToMeleenasShip());
        }

        protected override void DrawBackground()
        {
            UI.FillScreen("Placeholder/DockingBay");
        }
    }
}
