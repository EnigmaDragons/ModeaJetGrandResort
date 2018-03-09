using System;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Engine;

namespace SpaceResortMurder
{
    public class MainMenuScene : IScene
    {
        private TextButton button;
        private ClickUI clickUI;

        public MainMenuScene()
        {
            
        }

        public void Draw()
        {
            button.Draw(new Transform2(Vector2.Zero, Rotation2.Default, new Size2(700, 700), 1));
        }

        public void Init()
        {
            clickUI = new ClickUI();
            button = new TextButton(new Rectangle(0, 0, 500, 500), () => { }, "Start Game",
                Color.Red, new Color(175, 0, 0), new Color(95, 0, 0));
            clickUI.Add(button);
        }

        public void Update(TimeSpan delta)
        {
            clickUI.Update(delta);
        }
    }
}