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
        private IVisual _textboxDescription;
        private IVisual _border;
        private VisualClickableUIElement _confirm;
        private Label _shouldGuideLabel;
        private VisualClickableUIElement _guideMeButton;
        private VisualClickableUIElement _noGuideButton;

        public void Init()
        {
            _clickUI = new ClickUI();
            _keyboard = new KeyboardTyping(GameResources.DefaultPlayerCharacterName);
            _textboxDescription = new Label { Text = "Player Name", Transform = new Transform2(new Vector2(860, 400), new Size2(200, 50)) };
            _border = new ColoredRectangle { Color = Color.White, Transform = new Transform2(new Vector2(758, 498), new Size2(404, 79)) };
            _textboxLabel = new Label { Text = GameResources.DefaultPlayerCharacterName, Transform = new Transform2(new Vector2(760, 500), new Size2(400, 75)), BackgroundColor = Color.Black };
            _confirm = UiButtons.Menu("Confirm", new Vector2(780, 600), () =>
            {
                CurrentGameState.PlayerName = _keyboard.Result;
                CurrentGameState.CurrentLocation = nameof(PoliceCruiserInterior);
                Scene.NavigateTo(GameResources.LoadingSceneName);
            });
            _clickUI.Add(_confirm);
            _shouldGuideLabel = new Label() { Text = "Guide Me a Little", Transform = new Transform2(new Vector2(760, 700), new Size2(400, 75)) };
            _guideMeButton = UiButtons.Menu("Guide Me a Little", new Vector2(550, 800), () =>
            {
                CurrentGameState.ShowObjectives = true;
                _shouldGuideLabel.Text = "Guide Me a Little";
            });
            _clickUI.Add(_guideMeButton);
            _noGuideButton = UiButtons.Menu("I Know What I'm Doing", new Vector2(1010, 800), () =>
            {
                CurrentGameState.ShowObjectives = false;
                _shouldGuideLabel.Text = "I Know What I'm Doing";
            });
            _clickUI.Add(_noGuideButton);
        }

        public void Update(TimeSpan delta)
        {
            _clickUI.Update(delta);
            _keyboard.Update(delta);
            _textboxLabel.Text = _keyboard.Result;
        }

        public void Draw()
        {
            _textboxDescription.Draw();
            _border.Draw();
            _textboxLabel.Draw();
            _confirm.Draw();
            _shouldGuideLabel.Draw();
            _guideMeButton.Draw();
            _noGuideButton.Draw();
        }

        public void Dispose()
        {
            _clickUI.Dispose();
        }
    }
}
