using System;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder
{
    public class CreditsScene : IScene
    {
        private ClickUI clickUI;
        private TextButton menu;

        public void Draw()
        {
            menu.Draw(new Transform2(Vector2.Zero));
        }

        public void Init()
        {
            clickUI = new ClickUI();
            menu = new TextButton(new Rectangle(700, 800, 200, 50), () => { Scene.NavigateTo("Main Menu"); }, "Main Menu",
                Color.Red, new Color(175, 0, 0), new Color(95, 0, 0));
            clickUI.Add(menu);
        }

        public void Update(TimeSpan delta)
        {
            clickUI.Update(delta);
        }
    }
}