using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Clues.CloningRoom;

namespace SpaceResortMurder.LocationsX
{
    public class TravissCloningRoomScene : LocationScene
    {
        protected override string Name => "Travis's Cloning Room";

        public TravissCloningRoomScene() : base(nameof(TravissCloningRoom)) {}

        protected override void OnInit()
        {
            AddClue(new CloningChamber());
        }

        protected override void DrawBackground()
        {
            UI.FillScreen("Placeholder/CloningRoom");
        }
    }
}
