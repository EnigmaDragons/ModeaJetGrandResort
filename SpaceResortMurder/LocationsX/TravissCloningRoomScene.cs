using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Clues.CloningRoom;
using SpaceResortMurder.Pathways;

namespace SpaceResortMurder.LocationsX
{
    public class TravissCloningRoomScene : LocationScene
    {
        protected override string Name => "Travis's Cloning Room";

        public TravissCloningRoomScene() : base(nameof(TravissCloningRoom)) {}

        protected override void OnInit()
        {
            AddClue(new CloningChamber());
            AddPathway(new CloningRoomToLobby());
        }

        protected override void DrawBackground()
        {
            UI.FillScreen("Placeholder/CloningRoom");
        }
    }
}
