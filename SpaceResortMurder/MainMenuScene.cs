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
        private TextButton start;
        private TextButton credits;
        private ClickUI clickUI;

        public MainMenuScene()
        {
            
        }

        public void Draw()
        {
            start.Draw(new Transform2(Vector2.Zero));
            credits.Draw(new Transform2(Vector2.Zero));
        }

        public void Init()
        {
            clickUI = new ClickUI();
            start = new TextButton(new Rectangle(700, 300, 200, 100), () => { }, "Start Game",
                Color.Red, new Color(175, 0, 0), new Color(95, 0, 0));
            credits = new TextButton(new Rectangle(700, 500, 200, 100), () => { Scene.NavigateTo("Credits"); }, "View Credits",
                Color.Red, new Color(175, 0, 0), new Color(95, 0, 0));
            clickUI.Add(start);
            clickUI.Add(credits);
        }

        public void Update(TimeSpan delta)
        {
            clickUI.Update(delta);
        }
    }
}