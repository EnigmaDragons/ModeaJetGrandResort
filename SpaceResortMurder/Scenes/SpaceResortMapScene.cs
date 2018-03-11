using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.LocationStuff;

namespace SpaceResortMurder.Scenes
{
    public class SpaceResortMapScene : JamScene
    {
        private IReadOnlyList<Location> _locations;
        private ImageBox _background;

        protected override void OnInit()
        {
            _locations = GameObjects.Locations.GetAvailableLocations();
            _background = new ImageBox(new Transform2(new Vector2(350, 0), new Size2(900, 900)), "Placeholder/SpaceResortPlaceholder");
            _locations.ForEach(x => Add(x.Button));
        }

        protected override void DrawBackground()
        {
            _background.Draw(Transform2.Zero);
        }

        protected override void DrawForeground() {}
    }
}
