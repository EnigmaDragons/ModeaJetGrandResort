using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.LocationsX;
using SpaceResortMurder.State;
using SpaceResortMurder.Style;
using System;

namespace SpaceResortMurder.Scenes
{
    public class PickNameScene : IScene
    {
        private ClickUI _clickUI;
        private KeyboardTyping _keyboard;
        private Label _textboxLabel;
        private IVisual[] _visuals;

        public void Init()
        {
            _clickUI = new ClickUI();
            _keyboard = new KeyboardTyping(GameResources.DefaultPlayerCharacterName);
            _visuals = new IVisual[4];
            _visuals[0] = new Label { Text = "Player Name", Transform = new Transform2(new Vector2(860, 400), new Size2(200, 50)) };
            _visuals[1] = new ColoredRectangle { Color = Color.White, Transform = new Transform2(new Vector2(758, 498), new Size2(404, 79)) };
            _textboxLabel = new Label { Text = GameResources.DefaultPlayerCharacterName, Transform = new Transform2(new Vector2(760, 500), new Size2(400, 75)), BackgroundColor = Color.Black };
            _visuals[2] = _textboxLabel;
            var confirm = UiButtons.Menu("Confirm", new Vector2(780, 600), () =>
            {
                CurrentGameState.PlayerName = _keyboard.Result;
                CurrentGameState.CurrentLocation = nameof(PoliceCruiserInterior);
                Scene.NavigateTo(GameResources.LoadingSceneName);
            });
            _visuals[3] = confirm;
            _clickUI.Add(confirm);
        }

        public void Update(TimeSpan delta)
        {
            _clickUI.Update(delta);
            _keyboard.Update(delta);
            _textboxLabel.Text = _keyboard.Result;
        }

        public void Draw()
        {
            _visuals.ForEach(v => v.Draw());
        }

        public void Dispose()
        {
            _clickUI.Dispose();
        }
    }
}
