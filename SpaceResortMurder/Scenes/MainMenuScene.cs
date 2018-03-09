using Microsoft.Xna.Framework;
using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using System;
using MonoDragons.Core.EventSystem;
using SpaceResortMurder.Pondering;

namespace SpaceResortMurder.Scenes
{
    public class MainMenuScene : IScene
    {
        private TextButton _start;
        private TextButton _credits;
        private ClickUI _clickUi;

        public void Draw()
        {
            _start.Draw(new Transform2(Vector2.Zero));
            _credits.Draw(new Transform2(Vector2.Zero));
        }

        public void Init()
        {
            _clickUi = new ClickUI();
            _start = new TextButton(new Rectangle(700, 300, 200, 100), () =>
                {
                    Audio.PlaySound("MenuButtonPress");
                    GameState.Init();
                    Scene.NavigateTo("Pondering");
                }, "Start Game",
                Color.Red, new Color(175, 0, 0), new Color(95, 0, 0));
            _credits = new TextButton(new Rectangle(700, 500, 200, 100), () =>
                {
                    Audio.PlaySound("MenuButtonPress");
                    Scene.NavigateTo("Credits");
                }, "View Credits", Color.Red, new Color(175, 0, 0), new Color(95, 0, 0));
            _clickUi.Add(_start);
            _clickUi.Add(_credits);
        }

        public void Update(TimeSpan delta)
        {
            _clickUi.Update(delta);
        }
    }
}