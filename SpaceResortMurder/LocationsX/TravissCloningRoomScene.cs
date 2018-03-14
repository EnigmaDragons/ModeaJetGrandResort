using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.LocationsX
{
    public class TravissCloningRoomScene : LocationScene
    {
        public TravissCloningRoomScene() : base(GameObjects.Locations[nameof(TravissCloningRoom)]) {}

        protected override void OnInit() {}

        protected override void DrawBackground()
        {
            UI.FillScreen("Placeholder/CloningRoom");
        }
    }
}
