using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.LocationStuff;
using SpaceResortMurder.Style;

namespace SpaceResortMurder.Scenes
{
    public class SpaceResortMapScene : JamScene
    {
        private IReadOnlyList<Location> _locations;
        private ImageBox _background;

        protected override void OnInit()
        {
            _locations = GameObjects.Locations.GetAvailableLocations();
            _background = new ImageBox { Transform = new Transform2(new Vector2(350, 0), new Size2(900, 900)), Image = "Placeholder/SpaceResortPlaceholder" };
            _locations.ForEach(x => Add(x.Button));
            Add(UiButtons.Menu("Return", new Vector2(1250, 750), () => Scene.NavigateTo(GameState.Instance.CurrentLocation)));
        }

        protected override void DrawBackground()
        {
            _background.Draw(Transform2.Zero);
        }

        protected override void DrawForeground() {}
    }
}
