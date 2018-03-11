using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.LocationsX
{
    public class LobbyScene : LocationScene
    {
        public LobbyScene() : base(nameof(Lobby)) {}

        protected override void OnInit()
        {
            _visuals.Add(new ImageBox { Image = "Placeholder/Lobby", Transform = new Transform2(new Size2(1600, 900)) });
        }
    }
}
