using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.Scenes
{
    public class CreditsScene : IScene
    {
        private ClickUI _clickUi;
        private TextButton _menu;

        public void Draw()
        {
            _menu.Draw(Transform2.Zero);
        }

        public void Init()
        {
            Audio.PlayMusicOnce("Credits", 0.7f);
            _clickUi = new ClickUI();
            _menu = new TextButton(new Rectangle(700, 800, 200, 50), () =>
                {
                    Audio.PlaySound("MenuButtonPress");
                    Scene.NavigateTo("Main Menu");
                }, "Main Menu", Color.Red, new Color(175, 0, 0), new Color(95, 0, 0));
            _clickUi.Add(_menu);
        }

        public void Update(TimeSpan delta)
        {
            _clickUi.Update(delta);
        }
    }
}