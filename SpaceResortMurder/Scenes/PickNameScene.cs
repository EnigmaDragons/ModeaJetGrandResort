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
using MonoDragons.Core.Inputs;
using SpaceResortMurder.CharactersX;

namespace SpaceResortMurder.Scenes
{
    public class PickNameScene : JamScene
    {
        private KeyboardTyping _keyboard;
        private Label _textboxLabel;
        private Label _shouldGuideLabel;
        private PlayerCharacterView _playerCharacter;

        protected override void OnInit()
        {
            _playerCharacter = new PlayerCharacterView(() => true);
            var header = UiLabels.FullWidthHeaderLabel("New Game", Color.White);
            header.Transform.Location = new Vector2(header.Transform.Location.X, 158);
            Add(header);

            _keyboard = new KeyboardTyping(GameResources.DefaultPlayerCharacterName);
            Add(_keyboard);
            var yStart = 331;
            Add(new Label { Text = "Character Name", Transform = new Transform2(new Vector2(758, yStart), new Size2(400, 50)) });
            Add(new ColoredRectangle { Color = Color.FromNonPremultiplied(31, 185, 219, 199), Transform = new Transform2(new Vector2(758, yStart + 60 - 2), new Size2(404, 79)) });
            _textboxLabel = new Label { Text = GameResources.DefaultPlayerCharacterName, Transform = new Transform2(new Vector2(760, yStart + 60), new Size2(400, 75)), BackgroundColor  =Color.FromNonPremultiplied(25, 75, 110, 255) };
            Add(_textboxLabel);

            yStart = 541;
            Add(new Label { Text = "Difficulty", Transform = new Transform2(new Vector2(860, yStart), new Size2(200, 50)) });
            Add(new ColoredRectangle { Color = Color.FromNonPremultiplied(31, 185, 219, 199), Transform = new Transform2(new Vector2(758, yStart + 60 - 2), new Size2(404, 79)) });
            _shouldGuideLabel = new Label { Text = "Guide Me a Little", Transform = new Transform2(new Vector2(760, yStart + 60), new Size2(400, 75)), BackgroundColor = Color.FromNonPremultiplied(25, 75, 110, 255) };
            Add(_shouldGuideLabel);
            Add(UiButtons.MenuSmallBlue("Guide Me", new Vector2(700, yStart + 170), () =>
            {
                CurrentGameState.ShowObjectives = true;
                _shouldGuideLabel.Text = "Guide Me a Little";
            }));
            Add(UiButtons.MenuSmallBlue("I'm A Pro", new Vector2(980, yStart + 170), () =>
            {
                CurrentGameState.ShowObjectives = false;
                _shouldGuideLabel.Text = "I Know What I'm Doing";
            }));

            Input.On(Control.Start, StartGame);
            Add(UiButtons.Menu("Begin", new Vector2(780, 900), StartGame));
        }

        private void StartGame()
        {
            CurrentGameState.PlayerName = _keyboard.Result;
            CurrentGameState.CurrentLocation = nameof(PoliceCruiserInterior);
            Scene.NavigateTo(GameResources.LoadingSceneName);
        }

        protected override void OnUpdate(TimeSpan delta)
        {
            _playerCharacter.Update(delta);
            _textboxLabel.Text = _keyboard.Result;
        }

        protected override void DrawBackground()
        {
            UI.FillScreen("Locations/TitleScreenBg");
            UI.Darken(165);
        }

        protected override void DrawForeground()
        {
            _playerCharacter.Draw();
        }
    }
}
