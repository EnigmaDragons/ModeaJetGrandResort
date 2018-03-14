using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Clues.RaymondsSpaceCraft;
using SpaceResortMurder.Pathways;

namespace SpaceResortMurder.LocationsX
{
    public class RaymondsShipInteriorScene : LocationScene
    {
        protected override string Name => "Raymond's Craft";

        public RaymondsShipInteriorScene() : base(nameof(RaymondsShipInterior)) {}

        protected override void OnInit()
        {
            AddClue(new RaymondsCorpse());
            AddClue(new RaymondsPad());
            AddClue(new ShipsLogs());
            AddClue(new T71EnergyBlaster());
            AddPathway(new RaymondsShipToDockingBay());
        }

        protected override void DrawBackground()
        {
            UI.FillScreen("Placeholder/RaymondsShip");
        }
    }
}
