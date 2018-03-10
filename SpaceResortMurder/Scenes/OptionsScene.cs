using System;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using MonoDragons.Core.PhysicsEngine;
using Microsoft.Xna.Framework;

namespace SpaceResortMurder.Scenes
{
    public class OptionsScene : IScene
    {
        private TextButton _return;
        private ClickUI _clickUi;

        public void Draw()
        {
            _return.Draw(Transform2.Zero);
        }

        public void Init()
        {
            _clickUi = new ClickUI();
            _return = new TextButton(new Rectangle(700, 500, 200, 100), () => Scene.NavigateTo(GameState.Instance.CurrentLocation), "Return",
                Color.Red, new Color(175, 0, 0), new Color(95, 0, 0));
            _clickUi.Add(_return);
        }

        public void Update(TimeSpan delta)
        {
            _clickUi.Update(delta);
        }
    }
}