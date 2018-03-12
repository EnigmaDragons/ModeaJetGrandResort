using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Clues.MeleenasSpaceCraft;

namespace SpaceResortMurder.LocationsX
{
    public class MeleenasShipInteriorScene : LocationScene
    {

        protected override string Name => "Meleena's Space Craft";

        public MeleenasShipInteriorScene() : base(nameof(MeleenasShipInterior)) {}

        protected override void OnInit()
        {
            AddClue(new DataStick());
            AddClue(new SkeletonKey());
            AddClue(new HackingRig());
        }

        protected override void DrawBackground()
        {
            UI.FillScreen("Placeholder/MeleenasSpaceCraft");
        }
    }
}
