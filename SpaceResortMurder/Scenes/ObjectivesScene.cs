using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Style;

namespace SpaceResortMurder.Scenes
{
    public class ObjectivesScene : JamScene
    {
        private IVisual _description;

        protected override void OnInit()
        {
            _description = new Label
            {
                Transform = new Transform2(new Vector2(800, 0), new Size2(800, 900)),
                Text = "Select an objective to view",
                TextColor = Color.White,
                BackgroundColor = Color.FromNonPremultiplied(0, 0, 255, 150),
            };
            GameObjects.Objectives.GetActiveObjectives().ForEachIndex((x, i) => Add(x.CreateButton(() => _description = x.Description, (i + 1) * 50)));
            Add(UiButtons.Menu("Return", new Vector2(1250, 750), () => Scene.NavigateTo(GameState.Instance.CurrentLocation)));
        }

        protected override void DrawBackground() {}

        protected override void DrawForeground()
        {
            _description.Draw(Transform2.Zero);
        }
    }
}
