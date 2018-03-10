using Microsoft.Xna.Framework;
using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using System;

namespace SpaceResortMurder.Scenes
{
    public class MainMenuScene : IScene
    {
        private TextButton _start;
        private TextButton _credits;
        private TextButton _options;
        private ClickUI _clickUi;
        
        public void Init()
        {
            Audio.PlayMusic("MainTheme");
            GameState.Instance = new GameState();
            _clickUi = new ClickUI();
            _start = new TextButton(new Rectangle(700, 300, 200, 100), () =>
                {
                    Audio.PlaySound("MenuButtonPress");
                    Scene.NavigateTo("Pondering");
                }, "Start Game",
                Color.Red, new Color(175, 0, 0), new Color(95, 0, 0));
            _credits = new TextButton(new Rectangle(700, 500, 200, 100), () =>
                {
                    Audio.PlaySound("MenuButtonPress");
                    Scene.NavigateTo("Credits");
                }, "View Credits", Color.Red, new Color(175, 0, 0), new Color(95, 0, 0));
            _options = new TextButton(new Rectangle(700, 700, 200, 100), () =>
                {
                    GameState.Instance.CurrentLocation = "Main Menu";
                    Scene.NavigateTo("Options");
                },
                "Options", Color.Red, new Color(175, 0, 0), new Color(95, 0, 0));
            _clickUi.Add(_start);
            _clickUi.Add(_credits);
            _clickUi.Add(_options);
        }

        public void Update(TimeSpan delta)
        {
            _clickUi.Update(delta);
        }

        public void Draw()
        {
            _start.Draw(Transform2.Zero);
            _credits.Draw(Transform2.Zero);
            _options.Draw(Transform2.Zero);
        }
    }
}